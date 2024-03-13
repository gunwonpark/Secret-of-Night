using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region DataBases
    public PlayerLevelDataBase playerLevelDataBase;
    public PlayerSkillDataBase playerSkillDataBase;
    public PlayerStatDataBase playerStatDataBase;
    #endregion
    public void Initialize()
    {
        playerLevelDataBase = Utility.LoadJson<PlayerLevelDataBase>("playerLevel_Data");
        playerLevelDataBase.Initalize();
        playerSkillDataBase = Utility.LoadJson<PlayerSkillDataBase>("playerSkill_Data");
        playerSkillDataBase.Initalize();
        playerStatDataBase = Utility.LoadJson<PlayerStatDataBase>("playerStat_Data");
        playerStatDataBase.Initalize();
    }
}
