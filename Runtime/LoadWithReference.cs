using System.Collections;

using UnityEngine;
using UnityEngine.AddressableAssets;

using Sirenix.OdinInspector;

using TalusFramework.Utility.Logging;
using TalusFramework.Utility.Assertions;

namespace TalusLevelManagement
{
    public class LoadWithReference : MonoBehaviour
    {
        [LabelWidth(70)]
        [AssetList(AssetNamePrefix = "Var_")]
        [Required] public AssetReferenceVariable Reference;

        private IEnumerator Start()
        {
            this.Assert(Reference.RuntimeValue.RuntimeKeyIsValid(), "Asset reference is not valid!");

            var reference = Reference.RuntimeValue;
            var opHandle = reference.LoadAssetAsync<GameObject>();

            yield return opHandle;

            Instantiate(opHandle.Result);

            // Addressables.Release(opHandle);
        }
    }
}