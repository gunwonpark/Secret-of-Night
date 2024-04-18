using UnityEngine;
using UnityEngine.UI;

public class QuickInventorySettingItemSlot
{
    public Item item;
    public int count;
}

public class QuickSlotInventorySetting : MonoBehaviour
{
    // 퀵 슬롯 설정 창
    [SerializeField] private GameObject _quickInventoryUI;
    [SerializeField] private GameObject _slotGrid;

    bool activate;

    public QuickInventorySlots[] _uiSlots; // UI 슬롯
    public QuickInventorySettingItemSlot[] slots; // 슬롯내의 데이터

    private QuickInventorySettingItemSlot _selectedItem;
    private int _selectedItemIndex;

    public Button exitButton;

    private void Start()
    {
        Initalize();
        exitButton.onClick.AddListener(OnExit);
    }

    //private void Update()
    //{
    //    OpenQuickInventoryUI();
    //}

    private void Initalize()
    {
        _quickInventoryUI.SetActive(false);

        _uiSlots = _slotGrid.GetComponentsInChildren<QuickInventorySlots>();

        slots = new QuickInventorySettingItemSlot[_uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new QuickInventorySettingItemSlot();
            _uiSlots[i].index = i;
            _uiSlots[i].ClearSlot();
        }
    }


    //private void OpenQuickInventoryUI()
    //{
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        activate = !activate;

    //        if (activate)
    //        {
    //            OpenQuickInventory();
    //            Cursor.visible = true;
    //            Inventory.instance._playerController.Input.enabled = false;
    //        }
    //        else
    //        {
    //            _quickInventoryUI.SetActive(false);
    //            Cursor.visible = false;
    //            Inventory.instance._playerController.Input.enabled = true;
    //        }
    //    }
    //}

    public void OpenQuickInventory()
    {
        _quickInventoryUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Inventory.instance._playerController.Input.enabled = false;

    }

    private void CloseQuickInventory()
    {
        _quickInventoryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void OnExit()
    {
        _quickInventoryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Inventory.instance._playerController.Input.enabled = true;

    }

    public void AddItem(Item _item, int _quantity)
    {
        if (_item.Type == "using")
        {
            for (int i = 0; i < _quantity; i++)
            {
                QuickInventorySettingItemSlot slotStack = GetItemStack(_item);
                if (slotStack != null)
                {
                    slotStack.count++;
                }
                else
                {
                    QuickInventorySettingItemSlot emptySlot = GetEmptySlot();
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


    private QuickInventorySettingItemSlot GetItemStack(Item _item)
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

    private QuickInventorySettingItemSlot GetEmptySlot()
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

    public void RemoveSelectedItem()
    {
        if (_selectedItem != null)
        {
            _selectedItem.item = null;
            UpdateQuickSlot();
        }

        UpdateQuickSlot();
    }

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
                UpdateQuickSlot();
                break;
            }
        }

    }
}
