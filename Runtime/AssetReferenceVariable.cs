using UnityEngine;
using UnityEngine.AddressableAssets;

using TalusFramework.Variables.Interfaces;

namespace TalusLevelManagement
{
    [CreateAssetMenu(fileName = "New Asset Reference Variable", menuName = "Variables/Asset Reference", order = 11)]
    public sealed class AssetReferenceVariable : BaseVariable<AssetReference>
    {
        public override bool AreValuesEqual(AssetReference value) => ReferenceEquals(RuntimeValue, value);
    }
}
