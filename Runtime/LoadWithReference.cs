using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Variables;

namespace TalusLevelManagement
{
    public class LoadWithReference : MonoBehaviour
    {
        [LabelWidth(70)]
        [AssetList(AssetNamePrefix = "Var_")]
        [Required] public GameObjectVariable Reference;

        private void Start()
        {
            Instantiate(Reference.RuntimeValue, transform);
        }
    }
}