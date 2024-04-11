using System.Collections.Generic;
using UnityEngine;

public class LoadPopup : UIBase
{
    [SerializeField] private Transform _slotRoot;

    private List<CharacterSlot> slots;
    private int _defaultSlotNumber = 5;
    private void Awake()
    {
        slots = new(_defaultSlotNumber);
    }
    private void Start()
    {
        // 슬록을 5개 정도 생성한다
        for (int i = 0; i < _defaultSlotNumber; i++)
        {
            CreateCharacterSlot(i);
        }


    }
    void CreateCharacterSlot(int slotNumber)
    {
        // 만약 slotNumber에 맞는 데이터가 있으면 데이터를 불러온다
        if (GameManager.Instance.playerManager.playerDatas.ContainsKey(slotNumber))
        {
            slots.Add(GameManager.Instance.uiManager.MakeSubItem<CharacterSlot>(parent: _slotRoot));
        }
        //데이터가 없는경우 빈 슬록을 불러온다
        else
        {
            slots.Add(GameManager.Instance.uiManager.MakeSubItem<CharacterSlot>("EmptySlot", _slotRoot));
        }

        slots[slotNumber].SetSlotNumber(slotNumber);
        slots[slotNumber].Initialize();
    }
}
