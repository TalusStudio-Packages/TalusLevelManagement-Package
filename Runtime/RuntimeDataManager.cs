using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Managers.Interfaces;
using TalusFramework.Constants;
using TalusFramework.Variables;
using TalusFramework.Collections;
using TalusFramework.Utility.Assertions;

namespace TalusLevelManagement
{
    /// <summary>
    ///     RuntimeData Manager sets next level
    /// </summary>
    [CreateAssetMenu(fileName = "New Runtime Manager", menuName = "Talus/Framework/Managers/Runtime Manager", order = 1)]
    public class RuntimeDataManager : BaseManager
    {
        [LabelWidth(100)]
        [Required] public StringConstant LevelCyclePref;

        [LabelWidth(100)]
        [Required] public GameObjectCollection LevelCollection;

        [LabelWidth(100)]
        [Required] public GameObjectVariable NextLevel;

        private int CompletedLevelCount => PlayerPrefs.GetInt(LevelCyclePref.RuntimeValue);

        public override void Initialize()
        {
            this.Assert(LevelCyclePref != null, "Invalid Reference!", typeof(StringConstant), null);
            this.Assert(LevelCollection != null, "Invalid Reference!", typeof(SceneCollection), null);
            this.Assert(NextLevel != null, "Invalid Reference!", typeof(SceneVariable), null);

            RefreshLevelData();
        }

        public void LevelUp()
        {
            PlayerPrefs.SetInt(LevelCyclePref.RuntimeValue, CompletedLevelCount + 1);
            RefreshLevelData();
        }

        private void RefreshLevelData()
        {
            NextLevel.SetValue(LevelCollection[CompletedLevelCount % LevelCollection.Count]);
        }
    }
}