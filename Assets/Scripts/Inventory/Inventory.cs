using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool activated = false; // 인벤토리 활성화 시 다른 입력 못하게

    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private GameObject _slotGrid;

    private Slot[] slots; //슬롯들을 배열로 할당

    void Start()
    {
        slots = _slotGrid.GetComponentsInChildren<Slot>();
    }


    void Update()
    {
        OpenInventoryUI();
    }

    private void OpenInventoryUI()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            activated = !activated;

            if (activated)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    private void OpenInventory()
    {
        _inventoryUI.SetActive(true);
    }

    private void CloseInventory()
    {
        _inventoryUI?.SetActive(false);
    }

    //아이템 획득, 같은 이름을 가지고 있는 아이템일 경우에 +1
    public void PickupItem(ItemData _item, int _count = 1)
    {
        //장착 아이템이 아닐경우에만 (장착 아이템은 카운트 x)
        if (ItemType.Equipment != _item.type)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.name == _item.name)
                    {
                        slots[i].SlotCount(_count);
                        return;
                    }
                }
            }
        }

        // 같은 이름을 가지고 있는 아이템이 없다면 아이템 추가 (빈 슬롯이 있을 때)
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item);
                return;
            }
        }
    }
}
