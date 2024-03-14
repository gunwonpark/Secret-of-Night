using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Inventory : MonoBehaviour
{
    public static bool activated = false; // 인벤토리 활성화 시 다른 입력 못하게
    public static Inventory instance;

    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private GameObject _slotGrid;
    [SerializeField] private Slot[] _slots; //슬롯들을 배열로 할당

    // public Transform dropPosition; //드랍 위치

    [Header("Selected Item")]
    private Item _selectedItem;
    private int _selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    //public TextMeshProUGUI selectedItemStat;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject dropButton;


    // 페이지 넘기기 위한 변수
    private int _maxSlot = 12;
    private int _currentPage = 1;
    private int _totalPage = 3;

    public Button rightBtn;
    public Button leftBtn;


    void Start()
    {
        //비활성화 상태에서 오브젝트를 못 찾음
        // slots = _slotGrid.GetComponentsInChildren<Slot>();

        instance = this;
        ClearSeletecItemWindow(); //아이템 정보 보여주는 오브젝트 비활성화
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
        var endIndex = Mathf.Min(startIndex + _maxSlot, _slots.Length);

        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
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
    public void PickupItem(Item _item, int _count = 1)
    {
        //Debug.Log(_item);
        //장착 아이템이 아닐경우에만 (장착 아이템은 카운트 x)
        if (_item.Type != "Equip")
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].item != null)
                {
                    //Debug.Log(_slots[i].item.ItemName);
                    if (_slots[i].item.ItemName == _item.ItemName)
                    {
                        _slots[i].SlotCount(_count);
                        return;
                    }
                }
            }
        }

        // 같은 이름을 가지고 있는 아이템이 없다면 아이템 추가 (빈 슬롯이 있을 때)
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].item != null)
            {
                Debug.Log(i);
                if (_slots[i].item.Name == null || _slots[i].item.Name == "")
                {
                    _slots[i].AddItem(_item, _count);
                    return;
                }

                if (string.IsNullOrEmpty(_slots[i].item.ItemName))
                {
                    // Debug.Log(_count);
                    _slots[i].AddItem(_item, _count);
                    return;
                }
            }
            else
            {
                _slots[i].AddItem(_item, _count);
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
        var endIndex = Mathf.Min(startIndex + _maxSlot, _slots.Length);

        Debug.Log(startIndex);
        Debug.Log(endIndex);
        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
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
        var endIndex = Mathf.Min(startIndex + _maxSlot, _slots.Length);

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
        }

        rightBtn.gameObject.SetActive(true);
        leftBtn.gameObject.SetActive(_currentPage > 1);
    }

    // 다음페이지
    public void NextOnClick()
    {
        NextPage();
    }

    // 이전페이지
    public void PrevOnClick()
    {
        PrevPage();
    }

    // 나가기
    public void ExitOnClick()
    {
        _inventoryUI.SetActive(false);
    }

    //슬롯이 비워질 때
    private void ClearSeletecItemWindow()
    {
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }

    //아이템 슬롯 선택시 아이템 설명이 보이게
    public void UpdateSelectedItemInfo(Item selectedItem)
    {
        _selectedItem = selectedItem;
        selectedItemName.text = selectedItem.ItemName;
        selectedItemDescription.text = selectedItem.Description;
        //selectedItemStat.text = selectedItem.Price.ToString();      

        // 예시: 사용 버튼은 항상 활성화, 장착 버튼은 장착 가능한 경우에만 활성화되도록 설정
        useButton.SetActive(true);
        dropButton.SetActive(true);
    }

    //현재 선택한 아이템 사용하기
    public void UseButtonOnClick()
    {
        if (_selectedItem != null)
        {
            // 슬롯을 찾아 아이템 제거
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].item == _selectedItem)
                {
                    _slots[i].ClearSlot(); //슬롯 비우기
                    break;
                }
            }
            ClearSeletecItemWindow();
        }
    }
}
