using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : UIBase
{
    private LoadPopup _loadPopup;
    private SavePopup _savePopup;

    [SerializeField] private GameObject _emptySlot;
    [SerializeField] private GameObject _characterSlot;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _characterNameText;
    [SerializeField] private TextMeshProUGUI _chapterText;
    [SerializeField] private TextMeshProUGUI _saveDateText;

    [Header("Images")]
    [SerializeField] private Image _characterImage;
    [SerializeField] private Image _backGroundImage;

    private int _slotNumber;
    public bool isEmpty;

    public override void Initialize()
    {
        if (GetComponentInParent<SavePopup>() != null)
            _savePopup = GetComponentInParent<SavePopup>();
        if (GetComponentInParent<LoadPopup>() != null)
            _loadPopup = GetComponentInParent<LoadPopup>();

        ReFreshData();

        this.gameObject.BindEvent(OnCharacterSlotClick);
    }

    private void OnCharacterSlotClick()
    {
        if (_savePopup != null)
        {
            if (_savePopup.hasClickedSlot == true)
            {
                if (_savePopup.selectedSlotNumber == _slotNumber)
                {
                    _savePopup.hasClickedSlot = false;
                    _savePopup.selectedSlotNumber = -1;
                    _backGroundImage.color = Color.white;
                    return;
                }
                else
                {
                    //전에 선택된 슬롯의 색을 원래대로 되돌린다
                    _savePopup.GetSlot(_savePopup.selectedSlotNumber).ResetBackGroundColor();

                    _savePopup.hasClickedSlot = true;
                    _savePopup.selectedSlotNumber = _slotNumber;
                    _backGroundImage.color = Color.gray;
                    return;
                }
            }

            _savePopup.hasClickedSlot = true;
            _savePopup.selectedSlotNumber = _slotNumber;
            _backGroundImage.color = Color.gray;
        }
        else
        {
            if (_loadPopup.hasClickedSlot == true)
            {
                if (_loadPopup.selectedSlotNumber == _slotNumber)
                {
                    _loadPopup.hasClickedSlot = false;
                    _loadPopup.selectedSlotNumber = -1;
                    _backGroundImage.color = Color.white;
                    return;
                }
                else
                {
                    //전에 선택된 슬롯의 색을 원래대로 되돌린다
                    _loadPopup.GetSlot(_loadPopup.selectedSlotNumber).ResetBackGroundColor();

                    _loadPopup.hasClickedSlot = true;
                    _loadPopup.selectedSlotNumber = _slotNumber;
                    _backGroundImage.color = Color.gray;
                    return;
                }
            }

            _loadPopup.hasClickedSlot = true;
            _loadPopup.selectedSlotNumber = _slotNumber;
            _backGroundImage.color = Color.gray;
        }
    }
    public void ResetBackGroundColor()
    {
        _backGroundImage.color = Color.white;
    }
    public void ReFreshData()
    {
        if (GameManager.Instance.playerManager.playerDatas.ContainsKey(_slotNumber))
        {
            PlayerGameData data = GameManager.Instance.playerManager.playerDatas[_slotNumber];
            _characterNameText.text = data.CharacterName;
            _chapterText.text = data.ChapterInfo;
            _saveDateText.text = data.SaveTime.ToString();

            // 캐릭터의 Type나 ID에 따른 스프라이트 이미지도 있어야 된다

            isEmpty = false;
            _characterSlot.SetActive(true);
            _emptySlot.SetActive(false);
        }
        else
        {
            isEmpty = true;
            _characterSlot.SetActive(false);
            _emptySlot.SetActive(true);
        }
    }
    internal void SetSlotNumber(int slotNumber)
    {
        _slotNumber = slotNumber;
    }
}
