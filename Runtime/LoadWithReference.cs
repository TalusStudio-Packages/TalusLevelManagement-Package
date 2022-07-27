using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Logging;
using TalusFramework.Utility.Assertions;

using Sirenix.OdinInspector;

namespace TalusLevelManagement
{
    public class LoadWithReference : BaseBehaviour
    {
        [LabelWidth(70)]
        public AssetReferenceVariable Reference;

        protected override void Awake()
        {
            this.Assert(Reference.RuntimeValue.RuntimeKeyIsValid(), "Asset reference is not valid!");
        }

        protected override void Start()
        {
            AsyncOperationHandle handle = Reference.RuntimeValue.LoadAssetAsync<GameObject>();
            handle.Completed += Handle_Completed;
        }

        private void Handle_Completed(AsyncOperationHandle obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(Reference.RuntimeValue.Asset, transform);
                return;
            }

            this.Error($"AssetReference {Reference.RuntimeValue.RuntimeKey} failed to load!");
        }

        private void OnDestroy()
        {
            Reference.RuntimeValue.ReleaseAsset();
        }
    }
}
