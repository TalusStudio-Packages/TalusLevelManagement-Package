using UnityEngine;
using UnityEngine.AddressableAssets;
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
        [AssetList(AssetNamePrefix = "Var_")]
        [Required] public AssetReferenceVariable Reference;

        private AsyncOperationHandle<GameObject> _opHandle;

        protected override void Start()
        {
            this.Assert(Reference.RuntimeValue.RuntimeKeyIsValid(), "Asset reference is not valid!");

            _opHandle = Addressables.LoadAssetAsync<GameObject>(Reference.RuntimeValue);
            _opHandle.Completed += HandleWhenComplete;
        }

        private void HandleWhenComplete(AsyncOperationHandle<GameObject> obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(obj.Result, transform);
                return;
            }

            Addressables.Release(obj);
            this.Error($"AssetReference {Reference.RuntimeValue.RuntimeKey} failed to load!");
        }

        private void OnDestroy()
        {
            Addressables.Release(_opHandle);
        }
    }
}
