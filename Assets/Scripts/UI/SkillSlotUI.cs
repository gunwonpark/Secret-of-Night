using System.Collections.Generic;

public class SkillSlotUI : UIBase
{
    public List<SkillSlot> skillSlots = new List<SkillSlot>();

    public override void Initialize()
    {
        List<int> unlockedSkillList = GameManager.Instance.playerManager.GetUnlockedSkillSlotNumber();
        GameManager.Instance.playerManager.skillSlots.Clear();

        //데이터가 있는 경우 추후 스킬 slot을 초기화 해줘야 된다
        for (int i = 0; i < skillSlots.Count; i++)
        {
            GameManager.Instance.playerManager.skillSlots.Add(skillSlots[i]);
            //if (unlockedSkillList.Contains(i))
            GameManager.Instance.playerManager.ActiveSkillSlot(i);
        }
    }

}
