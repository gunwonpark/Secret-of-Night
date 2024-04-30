using System.Collections.Generic;
using UnityEngine;

public class SkillSlotUI : UIBase
{
    public List<SkillSlot> skillSlots = new List<SkillSlot>();

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("SkillSlotUI Initialize");
        GameManager.Instance.playerManager.skillSlots.Clear();
        Debug.Log("SkillSlotUI Initialize1");
        //데이터가 있는 경우 추후 스킬 slot을 초기화 해줘야 된다
        for (int i = 0; i < skillSlots.Count; i++)
        {
            Debug.Log("SkillSlotUI Initializ2");
            GameManager.Instance.playerManager.skillSlots.Add(skillSlots[i]);
            Debug.Log("SkillSlotUI Initializ3");
            if (GameManager.Instance.playerManager.playerData.skillSlots[i])
                GameManager.Instance.playerManager.ActiveSkillSlot(i);
        }
    }

}
