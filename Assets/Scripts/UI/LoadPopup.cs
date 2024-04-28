using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPopup : UIBase
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
            if (slots[selectedSlotNumber].isEmpty)
            {
                GameManager.Instance.playerManager.Initialize(1);
                GameManager.Instance.playerManager.playerDatas.Add(selectedSlotNumber, GameManager.Instance.playerManager.playerData);
                GameManager.Instance.playerManager.playerData.SaveTime = DateTime.Now.ToString();
                GameManager.Instance.sceneManager.LoadSceneAsync(Scene.Main);
            }
            else
            {
                GameManager.Instance.playerManager.Init(selectedSlotNumber);
                GameManager.Instance.playerManager.playerData.SaveTime = DateTime.Now.ToString();
                GameManager.Instance.sceneManager.LoadSceneAsync(Scene.Main);
            }
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
