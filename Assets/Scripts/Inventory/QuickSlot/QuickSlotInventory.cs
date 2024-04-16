using UnityEngine;

public class QuickInventoryItemSlot
{
    public Item item;
    public int count;
}
public class QuickSlotInventory : MonoBehaviour
{
    private QuickSlotInventorySetting quickSlotInventorySetting;

    // 퀵 슬롯 설정 창
    [SerializeField] private GameObject _quickSlotUI;
    [SerializeField] private GameObject _slotGrid;
    [SerializeField] private Transform _itemGroup; // _slotGrid의 Transform

    private int slotWidth = 110;

    bool activate;

    public QuickSlots[] _uiSlots; // UI 슬롯
    public QuickInventoryItemSlot[] slots; // 슬롯내의 데이터

    private QuickInventoryItemSlot _selectedItem;
    public int _selectedItemIndex = 1;


    private void Start()
    {
        Initalize();
        quickSlotInventorySetting = GetComponent<QuickSlotInventorySetting>();
    }

    private void Initalize()
    {

        _uiSlots = _slotGrid.GetComponentsInChildren<QuickSlots>();

        slots = new QuickInventoryItemSlot[_uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new QuickInventoryItemSlot();
            _uiSlots[i].index = i;
            _uiSlots[i].ClearSlot();
        }

        _selectedItem = slots[_selectedItemIndex];
    }

    private void Update()
    {
        QuickSlotItemUse();
        QuickSlotItemClear();
        MoveSlot();
    }

    //------------------------------------------------------------------------

    // 슬롯 이동
    public void MoveSlot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // 왼쪽으로 슬롯 이동
            if (_selectedItemIndex > 0)
            {
                _selectedItemIndex--;
                MoveItemGroup(slotWidth); // ItemGroup을 왼쪽으로 이동
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            // 오른쪽으로 슬롯 이동
            if (_selectedItemIndex < slots.Length - 1)
            {
                _selectedItemIndex++;
                MoveItemGroup(-slotWidth); // ItemGroup을 오른쪽으로 이동
            }
        }
    }

    // ItemGroup을 이동시키는 함수
    private void MoveItemGroup(float xOffset)
    {
        Debug.Log(_selectedItemIndex);
        Vector3 newPosition;

        newPosition = _itemGroup.localPosition + new Vector3(xOffset, 0f, 0f);

        _itemGroup.localPosition = newPosition;
    }

    //---------------------------------------------------------------------------------

    // 퀵슬롯 아이템 사용
    public void QuickSlotItemUse()
    {
        Inventory.instance.SelectItem(_selectedItemIndex);
        SelectItem(_selectedItemIndex);

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (slots[_selectedItemIndex].item != null)
            {
                OnUseButton();
            }
            else // 아이템이 없을 땐 설정 창
            {
                quickSlotInventorySetting.OpenQuickInventory();

            }
        }

    }

    // 퀵슬롯에서 아이템 해제
    public void QuickSlotItemClear()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (slots[_selectedItemIndex].item != null)
            {
                quickSlotInventorySetting.AddItem(slots[_selectedItemIndex].item, slots[_selectedItemIndex].count);
                RemoveSelectedItem(slots[_selectedItemIndex].count);

            }
        }
    }

    public void AddItem(Item _item, int _quantity)
    {
        if (_item.Type == "using")
        {
            QuickInventoryItemSlot slotStack = slots[_selectedItemIndex]; // 선택된 슬롯 가져오기

            if (slotStack != null)
            {
                slotStack.item = _item; // 아이템 설정
                slotStack.count = _quantity; // 수량 설정
            }

            // 퀵 슬롯 업데이트
            UpdateQuickSlot();
        }
    }
    private QuickInventoryItemSlot GetItemStack(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == _item && slots[i].count < _item.MaxAmount)
            {
                return slots[i];
            }
        }
        return null;
    }

    private QuickInventoryItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }

    public void OnUseButton()
    {
        Inventory.instance.RemoveItemByID(_selectedItem.item.ItemID, 1);
        Inventory.instance.InventoryTrim();

        switch (_selectedItem.item.ItemID)
        {
            case 1:
                Inventory.instance._playerCondition.SmallHpPotion(_selectedItem.item.Price); break;
            case 2:
                Inventory.instance._playerCondition.BigHpPotion(_selectedItem.item.Price); break;
            case 3:
                Inventory.instance._playerCondition.SmallMpPotion(_selectedItem.item.Price); break;
            case 4:
                Inventory.instance._playerCondition.BigMpPotion(_selectedItem.item.Price); break;
            case 5:
                Inventory.instance._playerCondition.SmallSpPotion(_selectedItem.item.Price); break;
            case 6:
                Inventory.instance._playerCondition.BigSpPotion(_selectedItem.item.Price); break;
            case 7:
                if (!Inventory.instance._playerCondition.speedItemInUse) // 중복 사용 방지
                {
                    Inventory.instance._playerCondition.SpeedPotion(_selectedItem.item.Price);
                }
                else
                {
                    Debug.Log("이미 아이템 사용중");
                    return; // 중복 사용이므로 이후 코드 실행하지 않음
                }
                break;

        }
        RemoveSelectedItem(1);


    }


    public void UpdateQuickSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null && slots[i].item.Type == "using")
            {
                _uiSlots[i].QuickSet(slots[i]);
            }
            else
            {
                _uiSlots[i].ClearSlot();
            }
        }
    }


    public void SelectItem(int _index)
    {

        if (slots[_index].item == null)
        {
            return;
        }
        _selectedItem = slots[_index];
        _selectedItemIndex = _index;
    }

    public void RemoveSelectedItem(int quantity)
    {
        // _selectedItem.count -= quantity;
        slots[_selectedItemIndex].count -= quantity;

        if (slots[_selectedItemIndex].count <= 0)
        {
            //_selectedItem.item = null;
            slots[_selectedItemIndex].item = null;
        }
        Debug.Log(_selectedItemIndex);

        UpdateQuickSlot();
    }

    // 퀵 슬롯에서 아이템 사용 시 인벤토리에서 일치하는 아이템도 같이 삭제
    public void RemoveItemByID(int itemID, int quantity)
    {
        for (int i = 0; i < _uiSlots.Length; i++)
        {
            if (slots[i].item != null && slots[i].item.ItemID == itemID)
            {
                slots[i].count -= quantity;

                if (slots[i].count <= 0)
                {
                    slots[i].item = null;
                    slots[i].count = 0;

                }

                Inventory.instance.UpdateUI();
                break;
            }
        }
    }
}
