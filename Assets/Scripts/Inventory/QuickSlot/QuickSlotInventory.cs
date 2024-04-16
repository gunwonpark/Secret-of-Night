using UnityEngine;

public class QuickInventoryItemSlot
{
    public Item item;
    public int count;
}
public class QuickSlotInventory : MonoBehaviour
{
    // 퀵 슬롯 설정 창
    [SerializeField] private GameObject _quickSlotUI;
    [SerializeField] private GameObject _slotGrid;
    [SerializeField] private Transform _itemGroup; // _slotGrid의 Transform

    private int slotWidth = 110;

    bool activate;

    public QuickSlots[] _uiSlots; // UI 슬롯
    public QuickInventoryItemSlot[] slots; // 슬롯내의 데이터

    private QuickInventoryItemSlot _selectedItem;
    private int _selectedItemIndex;


    private void Start()
    {
        Initalize();
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
    }

    private void Update()
    {
        QuickSlotItemUse();
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
                MoveItemGroup(-slotWidth); // ItemGroup을 왼쪽으로 이동
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            // 오른쪽으로 슬롯 이동
            if (_selectedItemIndex < slots.Length - 1)
            {
                _selectedItemIndex++;
                MoveItemGroup(slotWidth); // ItemGroup을 오른쪽으로 이동
            }
        }
    }

    // ItemGroup을 이동시키는 함수
    private void MoveItemGroup(float xOffset)
    {
        Vector3 newPosition = _itemGroup.localPosition + new Vector3(xOffset, 0f, 0f);
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
            if (!Inventory.instance._playerCondition.speedItemInUse) // 이동속도 아이템 중복 x
            {
                RemoveSelectedItem(1);
                Inventory.instance.OnUseButton();
            }
            else
            {
                return;
            }
        }
    }

    public void AddItem(Item _item, int _quantity)
    {
        if (_item.Type == "using")
        {
            for (int i = 0; i < _quantity; i++)
            {
                QuickInventoryItemSlot slotStack = GetItemStack(_item);
                if (slotStack != null)
                {
                    slotStack.count++;
                }
                else
                {
                    QuickInventoryItemSlot emptySlot = GetEmptySlot();
                    if (emptySlot != null)
                    {
                        emptySlot.item = _item;
                        emptySlot.count = 1;
                    }
                }

            }

            // 퀵 슬롯 업데이트
            UpdateQuickSlot();
        }
    }


    private void UpdateQuickSlot()
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
        _selectedItem.count -= quantity;

        if (_selectedItem.count <= 0)
        {
            _selectedItem.item = null;
        }

        UpdateQuickSlot();
    }
}
