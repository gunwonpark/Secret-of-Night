using UnityEngine;
using UnityEngine.UI;

// 스킬 슬롯을 관리하는 클래스
public class SkillSlot : MonoBehaviour
{
    public Image skillImage;
    public bool hasSKIll;
    public int skillID;
    public string skillName;

    public SkillCoolTimer Timer;
    public bool Update => Timer.update;
    public void SetSlot(int id)
    {
        skillID = id;
        hasSKIll = true;
        skillName = GameManager.Instance.playerManager.playerSkillList[id].playerSkillData.Name;
        skillImage.sprite = GameManager.Instance.playerManager.GetSKillImage(id).GetComponent<Image>().sprite;
        Timer.Init();
    }
    public void ResetSlot()
    {
        skillID = -1;
        hasSKIll = false;
    }
    public void Execute()
    {
        Timer.Execute(GameManager.Instance.playerManager.playerSkillList[skillID].playerSkillData.DelayTime);
    }
}
