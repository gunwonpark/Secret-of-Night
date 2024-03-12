using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static bool activated = false; // 인벤토리 활성화 시 다른 입력 못하게

    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private GameObject _slotGrid;
    [SerializeField] private Slot[] slots; //슬롯들을 배열로 할당


    // 페이지 넘기기 위한 변수
    private int _maxSlot = 12;
    private int _currentPage = 1;
    private int _totalPage = 3;

    public Button rightBtn;
    public Button leftBtn;

    void Start()
    {
        // slots = _slotGrid.GetComponentsInChildren<Slot>();
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
        var startIndex = (_currentPage - 1) * _maxSlot;
        var endIndex = Mathf.Min(startIndex + _maxSlot, slots.Length);

        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
        }

        //마우스 커서 표시
        Cursor.lockState = CursorLockMode.None;
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


    // 다음 슬롯 창
    private void NextPage()
    {
        if (_currentPage == _totalPage)
        {
            return;
        }
        _currentPage++;
        Debug.Log(_currentPage + " 페이지");

        //(0~11, 12~23, 24~35번 슬롯)
        var startIndex = (_currentPage - 1) * _maxSlot;
        var endIndex = Mathf.Min(startIndex + _maxSlot, slots.Length);

        Debug.Log(startIndex);
        Debug.Log(endIndex);
        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
        }

        leftBtn.gameObject.SetActive(true);
        rightBtn.gameObject.SetActive(_currentPage < _totalPage);
    }

    // 이전 슬롯 창
    private void PrevPage()
    {
        if (_currentPage == 1)
        {
            return;
        }
        _currentPage--;
        Debug.Log(_currentPage + " 페이지");

        var startIndex = (_currentPage - 1) * _maxSlot;
        var endIndex = Mathf.Min(startIndex + _maxSlot, slots.Length);

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
        }

        rightBtn.gameObject.SetActive(true);
        leftBtn.gameObject.SetActive(_currentPage > 1);
    }


    public void NextOnClick()
    {
        NextPage();
    }

    public void PrevOnClick()
    {
        PrevPage();
    }
}
