using UnityEngine;


public class DataManager : MonoBehaviour
{
    #region DataBases
    public PlayerLevelDataBase playerLevelDataBase;
    public PlayerSkillDataBase playerSkillDataBase;
    public PlayerStatDataBase playerStatDataBase;
    public BossMonsterStatDatabase bossMonsterStatDatabase;
    public ItemDataBase itemDataBase;
    #endregion

    public void Initialize()
    {
        playerLevelDataBase = Utility.LoadJson<PlayerLevelDataBase>("PlayerLevel_Data");
        playerLevelDataBase.Initalize();
        playerSkillDataBase = Utility.LoadJson<PlayerSkillDataBase>("PlayerSkill_Data");
        playerSkillDataBase.Initalize();
        playerStatDataBase = Utility.LoadJson<PlayerStatDataBase>("PlayerStat_Data");
        playerStatDataBase.Initalize();

        bossMonsterStatDatabase = Utility.LoadJson<BossMonsterStatDatabase>("BossMonsterStat_Data");
        bossMonsterStatDatabase.Initalize();

        itemDataBase = Utility.LoadJson<ItemDataBase>("Items_Data");
        itemDataBase.Initalize();

    }
}

