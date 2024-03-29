
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
    public static Inventory instance;

    public bool activated;
    private bool _speedItemUse;

    private CameraHandler _camera;
    private EquipController _equipController;
    private PlayerCondition _playerCondition;
    private PlayerController _playerController;

    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private GameObject _slotGrid;
    [SerializeField] private GameObject _statInfo; // 스탯 정보 
    public GameObject playerLight;

    public Slot[] _uiSlots; //슬롯들을 배열로 할당
    public ItemSlot[] slots; // 아이템 정보

    //public Transform dropPosition; // 아이템 드랍 위치

    [Header("Selected Item")]
    private ItemSlot _selectedItem;
    private int _selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatText;

    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject dropButton;

    private int curEquipIndex;

    [Header("Page")]
    // 페이지 넘기기 위한 변수
    private int _maxSlot = 12;
    private int _currentPage = 1;
    private int _totalPage = 3;

    public Button rightBtn;
    public Button leftBtn;

    [Header("Cash")]
    public TextMeshProUGUI cash;

    private void Awake()
    {
        instance = this;
        _camera = FindObjectOfType<CameraHandler>();
        _equipController = GetComponent<EquipController>();
        _playerCondition = GetComponent<PlayerCondition>();
        _playerController = GetComponent<PlayerController>();
        cash.text = GameManager.Instance.playerManager.playerData.Gold.ToString();
    }

    void Start()
    {
        _inventoryUI.SetActive(false);
        _statInfo.SetActive(false);

        slots = new ItemSlot[_uiSlots.Length];

        _uiSlots = _slotGrid.GetComponentsInChildren<Slot>();

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot(); // 슬롯의 요소들을 ItemSlot의 인스턴스로 초기화
            _uiSlots[i].index = i;
            _uiSlots[i].ClearSlot();
        }

        ClearSeletecItemWindow(); //아이템 정보 보여주는 오브젝트 비활성화
        CashUpdate();

    }

    void Update()
    {
        OpenInventoryUI();
    }

    public void CashUpdate()
    {
        cash.text = GameManager.Instance.playerManager.playerData.Gold.ToString();
    }

    private void OpenInventoryUI()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            activated = !activated;

            if (activated)
            {
                OpenInventory();
                _camera.enabled = false; // 카메라 비활성
                _playerController.Input.enabled = false; //플레이어 활동 비활성
                playerLight.SetActive(true);

            }
            else
            {
                CloseInventory();
                _camera.enabled = true;
                _playerController.Input.enabled = true;
                playerLight.SetActive(false);
            }
        }
    }

    private void OpenInventory()
    {

        var startIndex = (_currentPage - 1) * _maxSlot; // 시작 인덱스 0
        var endIndex = Mathf.Min(startIndex + _maxSlot, _uiSlots.Length); // 끝 인덱스 12

        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < _uiSlots.Length; i++)
        {
            _uiSlots[i].gameObject.SetActive(i >= startIndex && i < endIndex); // 0~11까지의 슬롯만 활성화
        }

        //마우스 커서 표시
        Cursor.lockState = CursorLockMode.None;
        _inventoryUI.SetActive(true);
    }

    public void CloseInventory()
    {
        _inventoryUI.SetActive(false);
    }

    // 다음 슬롯 창
    private void NextPage()
    {
        if (_currentPage == _totalPage) // 현재 페이지가 총 페이지와 같을 경우 리턴
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
        rightBtn.gameObject.SetActive(_currentPage < _totalPage); // 현재 페이지가 총 페이지보다 작을 때만 활성화
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
        leftBtn.gameObject.SetActive(_currentPage > 1); // 현재 페이지가 1보다 클 때만 (첫 페이지보다 클 때)
    }

    // 다음페이지
    public void OnNext()
    {
        NextPage();
    }

    // 이전페이지
    public void OnPrev()
    {
        PrevPage();
    }

    // 나가기
    public void OnExit()
    {
        _inventoryUI.SetActive(false);
        _camera.enabled = true;
        _playerController.Input.enabled = true;
        playerLight.SetActive(false);
    }

    //아이템 추가
    public void AddItem(Item _item)
    {
        if (_item.Type == "using") // 소모성 아이템은 수량 체크
        {
            ItemSlot slotStack = GetItemStack(_item);
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
            emptySlot.item = _item;
            emptySlot.count = 1;
            UpdateUI();
            return;
        }
        //꽉 차면 버리게
    }

    // 아이템 수량 추가
    private ItemSlot GetItemStack(Item _item)
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
    public void SelectItem(int _index)
    {
        if (slots[_index].item == null)
        {
            return;
        }
        _selectedItem = slots[_index];
        _selectedItemIndex = _index;
        selectedItemName.text = _selectedItem.item.ItemName;
        selectedItemDescription.text = _selectedItem.item.Description;

        _statInfo.SetActive(true);

        string statText = "";

        // Determine stat information based on item type and ID
        switch (_selectedItem.item.Type)
        {
            case "using":
                statText = UsingItemStatText();
                break;
            case "Equip":
                statText = EquipItemStatText();
                break;
        }

        selectedItemStatText.text = statText;

        // 예시: 사용 버튼은 항상 활성화, 장착 버튼은 장착 가능한 경우에만 활성화되도록 설정
        useButton.SetActive(_selectedItem.item.Type == "using");
        equipButton.SetActive(_selectedItem.item.Type == "Equip" && !_uiSlots[_index].equipped);
        unEquipButton.SetActive(_selectedItem.item.Type == "Equip" && _uiSlots[_index].equipped);
        dropButton.SetActive(true);
    }
    private string UsingItemStatText()
    {
        switch (_selectedItem.item.ItemID)
        {
            case 1:
            case 2:
                return "HP + " + _selectedItem.item.Price;
            case 3:
            case 4:
                return "MP + " + _selectedItem.item.Price;
            case 5:
            case 6:
                return "SP + " + _selectedItem.item.Price;
            case 7:
                return "Speed + " + _selectedItem.item.Price;
            default:
                return "";
        }
    }
    private string EquipItemStatText()
    {
        switch (_selectedItem.item.ItemID)
        {
            case 9:
            case 10:
            case 11:
                return "AD + " + _selectedItem.item.Damage;
            default:
                return "";
        }
    }

    //슬롯이 비워질 때
    private void ClearSeletecItemWindow()
    {
        _selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;

        _statInfo.SetActive(false);
        selectedItemStatText.text = string.Empty;

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
    public void OnUseButton()
    {
        if (_selectedItem.item.Type == "using")
        {
            switch (_selectedItem.item.ItemID)
            {
                case 1:
                    _playerCondition.SmallHpPotion(_selectedItem.item.Price); break;
                case 2:
                    _playerCondition.BigHpPotion(_selectedItem.item.Price); break;
                case 3:
                    _playerCondition.SmallMpPotion(_selectedItem.item.Price); break;
                case 4:
                    _playerCondition.BigMpPotion(_selectedItem.item.Price); break;
                case 5:
                    _playerCondition.SmallSpPotion(_selectedItem.item.Price); break;
                case 6:
                    _playerCondition.BigSpPotion(_selectedItem.item.Price); break;
                case 7:
                    if (!_playerCondition.speedItemInUse) // 중복 사용 방지
                    {
                        _playerCondition.SpeedPotion(_selectedItem.item.Price);
                    }
                    else
                    {
                        Debug.Log("이미 아이템 사용중");
                        return; // 중복 사용이므로 이후 코드 실행하지 않음
                    }
                    break;

            }
        }

        RemoveSelectedItem();
    }

    // 아이템 장착
    public void OnEquipBtton()
    {
        //_selectedItemIndex로 하면 장비가 이중으로 껴짐, curEquip에 기본 무기가 장착 되어 있으면 해제
        if (_uiSlots[curEquipIndex].equipped)
        {
            UnEquip(curEquipIndex);
        }

        _uiSlots[_selectedItemIndex].equipped = true;
        curEquipIndex = _selectedItemIndex;

        _equipController.PlayerNewEquip(_selectedItem.item);

        _equipController.EquipWeaponPower(_selectedItem.item.ItemID, _selectedItem.item.Damage); //공격력 증가
        UpdateUI();

        SelectItem(_selectedItemIndex);

    }
    void UnEquip(int _index)
    {
        _uiSlots[_index].equipped = false;
        _equipController.PlayerUnEquip();
        _equipController.UnEquipWeaponPower(); //기본 공격력으로 돌아가게        
        UpdateUI();

        if (_selectedItemIndex == _index)
        {
            SelectItem(_index);
        }
    }


    public void OnUnEquipButton()
    {
        UnEquip(_selectedItemIndex);
        // 아무것도 장착되어 있지 않다면
        if (!_uiSlots[curEquipIndex].equipped)
        {
            // 현재 선택한 아이템을 기본 무기로 설정하고 장착
            _equipController.EquipDefaultWeapon();
        }
    }

    public void OnDropButton()
    {
        ThrowItem(_selectedItem.item);
        RemoveSelectedItem();
    }

    // 아이템 버리기
    private void ThrowItem(Item _item)
    {
        //Instantiate(_item.Prefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360f));

        Vector3 throwPosition = transform.position + transform.forward * Random.Range(1.5f, 3f); //앞으로 1.5~3 거리만큼

        GameObject thrownItem = Instantiate(_item.Prefab, throwPosition, Quaternion.identity);

        // 던지는 힘
        Rigidbody itemRigidbody = thrownItem.GetComponent<Rigidbody>();

        if (itemRigidbody != null)
        {
            // 앞으로 2.5만큼의 힘으로 던지기
            itemRigidbody.AddForce(transform.forward * 2.5f, ForceMode.VelocityChange);

            // y 축 방향으로도 던지기 (포물선)
            itemRigidbody.AddForce(Vector3.up * 2.5f, ForceMode.VelocityChange);
        }
    }

    // 아이템 판매하기
    private void SaleItem()
    {
        //int money = _selectedItem.item.Money * (int)0.5;
        if (!_uiSlots[_selectedItemIndex].equipped)
        {
            GameManager.Instance.playerManager.playerData.Gold += _selectedItem.item.Money;
        }
    }


    // 현재 아이템 사용시 수량 감소 및 장착 된 무기는 해제
    private void RemoveSelectedItem()
    {
        _selectedItem.count--;

        //장착아이템은 수량이 0으로 표시되기 때문에
        if (_selectedItem.count <= 0)
        {
            if (_uiSlots[_selectedItemIndex].equipped) //현재 장착하고 있는 아이템 인덱스에서 확인해야함 (_selectItemIndex)
            {
                UnEquip(_selectedItemIndex);
            }

            _selectedItem.item = null;
            ClearSeletecItemWindow(); // 아이템 설명 비워지게
        }
        UpdateUI();
    }


}
