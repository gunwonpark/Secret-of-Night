using UnityEngine;

namespace PKW
{
    public class DataManager : MonoBehaviour
    {
        #region DataBases
        public PlayerLevelDataBase playerLevelDataBase;
        public PlayerSkillDataBase playerSkillDataBase;
        public PlayerStatDataBase playerStatDataBase;

        public ItemData itemData;
        #endregion
        public void Initialize()
        {
            playerLevelDataBase = Utility.LoadJson<PlayerLevelDataBase>("PlayerLevel_Data");
            playerLevelDataBase.Initalize();
            playerSkillDataBase = Utility.LoadJson<PlayerSkillDataBase>("PlayerSkill_Data");
            playerSkillDataBase.Initalize();
            playerStatDataBase = Utility.LoadJson<PlayerStatDataBase>("PlayerStat_Data");
            playerStatDataBase.Initalize();

            itemData = Utility.LoadJson<ItemData>("Items_Data");
            itemData.Initalize();


        }
    }
}
