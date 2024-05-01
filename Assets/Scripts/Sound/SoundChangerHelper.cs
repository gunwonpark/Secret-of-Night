using UnityEngine;

[RequireComponent(typeof(SoundChanger))]
public class SoundChangerHelper : MonoBehaviour
{
    private SoundChanger _soundChanger;
    void Start()
    {
        _soundChanger = GetComponent<SoundChanger>();
    }
    private void Update()
    {
        if (QuestManager.I.currentQuest.QuestID > 1032)
        {
            _soundChanger._exitBgm = SoundList.fieldBGMAfter;
            this.enabled = false;
        }
    }
}
