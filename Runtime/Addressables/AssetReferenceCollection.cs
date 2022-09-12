using UnityEngine;
using UnityEngine.AddressableAssets;

using TalusFramework.Collections.Interfaces;

namespace TalusLevelManagement
{
    [CreateAssetMenu(fileName = "Asset Reference Collection", menuName = "Collections/Asset Reference", order = 11)]
    public class AssetReferenceCollection : BaseCollection<AssetReference>
    { }
}
