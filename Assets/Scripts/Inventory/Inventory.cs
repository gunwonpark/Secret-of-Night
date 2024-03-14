
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot
{
    public Item item;
    public int count;
}

public class Inventory : MonoBehaviour
{
    private bool activated;
    public static Inventory instance;

    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private GameObject _slotGrid;

    [SerializeField] private Slot[] _uiSlots; //슬롯들을 배열로 할당
    public ItemSlot[] slots; // 아이템 정보

    public Transform dropPosition; // 아이템 드랍 위치

    [Header("Selected Item")]
    private ItemSlot _selectedItem;
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

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _inventoryUI.SetActive(false);
        slots = new ItemSlot[_uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            _uiSlots[i].index = i;
            _uiSlots[i].ClearSlot();
        }

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
        var endIndex = Mathf.Min(startIndex + _maxSlot, _uiSlots.Length);

        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < _uiSlots.Length; i++)
        {
            _uiSlots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
        }

        //마우스 커서 표시
        Cursor.lockState = CursorLockMode.None;
        _inventoryUI.SetActive(true);
    }

    private void CloseInventory()
    {
        _inventoryUI.SetActive(false);
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
        var endIndex = Mathf.Min(startIndex + _maxSlot, _uiSlots.Length);

        Debug.Log(startIndex);
        Debug.Log(endIndex);
        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < _uiSlots.Length; i++)
        {
            _uiSlots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
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
        var endIndex = Mathf.Min(startIndex + _maxSlot, _uiSlots.Length);

        for (int i = 0; i < _uiSlots.Length; i++)
        {
            _uiSlots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
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

    //아이템 추가
    public void AddItem(Item item)
    {
        if (item.Type == "using")
        {
            ItemSlot slotStack = GetItemStack(item);
            if (slotStack != null)
            {
                slotStack.count++;
                UpdateUI();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot(); // 빈 슬롯

        if (emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.count = 1;
            UpdateUI();
            return;
        }
        //꽉 차면 버리게
    }

    // 아이템 수량 추가
    private ItemSlot GetItemStack(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == item && slots[i].count < item.MaxAmount)
            {
                return slots[i];
            }
        }
        return null;
    }

    private ItemSlot GetEmptySlot()
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

    //아이템 슬롯 선택시 아이템 설명이 보이게
    public void SelectItem(int index)
    {
        if (slots[index].item == null)
        {
            return;
        }
        _selectedItem = slots[index];
        _selectedItemIndex = index;
        selectedItemName.text = _selectedItem.item.ItemName;
        selectedItemDescription.text = _selectedItem.item.Description;
        //selectedItemStat.text = selectedItem.Price.ToString();      

        // 예시: 사용 버튼은 항상 활성화, 장착 버튼은 장착 가능한 경우에만 활성화되도록 설정
        useButton.SetActive(_selectedItem.item.Type == "using");
        dropButton.SetActive(true);
    }

    //슬롯이 비워질 때
    private void ClearSeletecItemWindow()
    {
        _selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }

    void UpdateUI() //UI 업데이트
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
                _uiSlots[i].Set(slots[i]);
            else
                _uiSlots[i].ClearSlot();
        }
    }

    //현재 선택한 아이템 사용하기
    public void UseButtonOnClick()
    {
        if (_selectedItem.item.Type == "using")
        {
            for (int i = 0; i < _selectedItem.item.Type.Length; i++)
            {
                //회복,마나,스태미나 스탯변화
            }
        }

        RemoveSelectedItem();
    }

    public void OnDropButton()
    {
        ThrowItem(_selectedItem.item);
        RemoveSelectedItem();
    }

    private void ThrowItem(Item _item)
    {
        Instantiate(_item.Prefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360f));
    }

    private void RemoveSelectedItem()
    {
        _selectedItem.count--;

        if (_selectedItem.count <= 0)
        {
            if (_uiSlots[_selectedItemIndex].equipped)
            {
                //장착중이면 해제
            }

            _selectedItem.item = null;
            ClearSeletecItemWindow();
        }

        UpdateUI();
    }

}
