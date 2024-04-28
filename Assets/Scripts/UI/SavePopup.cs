using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePopup : UIBase
{
    [SerializeField] private Transform _slotRoot;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private Button _cancelButton;

    private List<CharacterSlot> slots;

    public int selectedSlotNumber;
    public bool hasClickedSlot;
    private void Awake()
    {
        slots = new(GameManager.Instance.playerManager.maxSlotDataNumber);
    }
    private void Start()
    {
        // 슬록을 5개 정도 생성한다
        for (int i = 0; i < GameManager.Instance.playerManager.maxSlotDataNumber; i++)
        {
            CreateCharacterSlot(i);
        }

        _confirmButton.onClick.AddListener(() =>
        {
            GameManager.Instance.playerManager.playerData.SlotNumber = selectedSlotNumber;
            GameManager.Instance.playerManager.playerData.SaveData();
            if (GameManager.Instance.playerManager.playerDatas.ContainsKey(selectedSlotNumber))
            {
                GameManager.Instance.playerManager.playerDatas[selectedSlotNumber] = GameManager.Instance.playerManager.playerData;
            }
            else
            {
                GameManager.Instance.playerManager.playerDatas.Add(selectedSlotNumber, GameManager.Instance.playerManager.playerData);
            }

            slots[selectedSlotNumber].ReFreshData();
        });
        _cancelButton.onClick.AddListener(() => { Destroy(gameObject); });

    }
    void CreateCharacterSlot(int slotNumber)
    {
        slots.Add(GameManager.Instance.uiManager.MakeSubItem<CharacterSlot>(parent: _slotRoot));

        slots[slotNumber].SetSlotNumber(slotNumber);
        slots[slotNumber].Initialize();
    }
    public CharacterSlot GetSlot(int index)
    {
        return slots[index];
    }
}
