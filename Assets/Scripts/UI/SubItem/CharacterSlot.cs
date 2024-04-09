using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : UIBase
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _characterNameText;
    [SerializeField] private TextMeshProUGUI _chapterText;
    [SerializeField] private TextMeshProUGUI _saveDateText;

    [Header("Images")]
    [SerializeField] private Image _characterImage;

    private int _slotNumber;

    public override void Initialize()
    {
        if (GameManager.Instance.playerManager.playerDatas.ContainsKey(_slotNumber))
        {
            PlayerGameData data = GameManager.Instance.playerManager.playerDatas[_slotNumber];
            _characterNameText.text = data.CharacterName;
            _chapterText.text = data.ChapterInfo;
            _saveDateText.text = data.SaveTime.ToString();

            // 캐릭터의 Type나 ID에 따른 스프라이트 이미지도 있어야 된다
        }
    }

    internal void SetSlotNumber(int slotNumber)
    {
        _slotNumber = slotNumber;
    }
}
