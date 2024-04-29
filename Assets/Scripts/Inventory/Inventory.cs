
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class ItemSlot
{
    public Item item;
    public int count;
}

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [HideInInspector] public bool activated; // 인벤 활성화
    private bool _speedItemUse; // 스피드 아이템 활성화
    [HideInInspector] public bool sale_Inventory; // 판매용 인벤토리 활성화
    [HideInInspector] public bool npcInteraction = false; // npc와 대화 활성화

    private EquipController _equipController;
    [HideInInspector] public PlayerCondition _playerCondition;
    [HideInInspector] public PlayerController _playerController;
    public QuickSlotInventory _quickSlotInventory;


    public GameObject _inventoryUI;
    [SerializeField] private GameObject _slotGrid;
    [SerializeField] private GameObject _statIcon; // 스탯 정보 
    public GameObject playerLight;

    public Slot[] _uiSlots; //슬롯들을 배열로 할당
    public ItemSlot[] slots; // 아이템 정보

    //public Transform dropPosition; // 아이템 드랍 위치

    [Header("Selected Item")]
    public ItemSlot _selectedItem;
    public int _selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatText;

    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject dropButton;
    public GameObject saleButton;

    private int curEquipIndex;

    [Header("Page")]
    // 페이지 넘기기 위한 변수
    private int _maxSlot = 12;
    private int _currentPage = 1;
    private int _totalPage = 3;

    public Button rightBtn;
    public Button leftBtn;
    public Button exitBtn;

    public Button sortBtn;
    private Button trimBtn;

    [Header("Pop-Up")]
    public GameObject popUpUI;
    public GameObject checkBtn;
    public TextMeshProUGUI popUpText;

    [Header("Cash")]
    public TextMeshProUGUI cash;

    [Header("SalePop-Up")]
    public GameObject salePopUpUI;
    public TMP_InputField quantityInput; // 수량 입력
    private int _currentQuantity;
    public GameObject saleCheckBtn;
    public GameObject saleCancleBtn;
    public TextMeshProUGUI ItemNameText;

    public GameObject _playerStatIcon;

    [Header("OptionUI")]
    public GameObject optionUI;
    public Button menuRButton;
    public GameObject InvenUi;
    public Button InvenIcon;

    //상점에서 판매하기 G키 활성화를 이벤트로 델리게이트 사용
    public delegate void InventoryEvent();
    public static event InventoryEvent OnInventoryClose;
    public static event InventoryEvent OnInventoryOpen;


    private void Awake()
    {
        instance = this;
        _equipController = GetComponent<EquipController>();
        _playerCondition = GetComponent<PlayerCondition>();
        _playerController = GetComponent<PlayerController>();
        _quickSlotInventory = FindObjectOfType<QuickSlotInventory>();
    }

    void Start()
    {
        Initialize();
        ButtonEvent();
        InvenIcon.onClick.AddListener(OpenInventory);
    }

    void Update()
    {
        OpenInventoryUI();
    }

    //인벤토리 초기화
    public void Initialize()
    {
        _inventoryUI.SetActive(false);

        _playerStatIcon.BindEvent(OnStatIconClick);

        _statIcon.SetActive(false);
        popUpUI.SetActive(false);

        CashUpdate();

        _uiSlots = _slotGrid.GetComponentsInChildren<Slot>();
        slots = new ItemSlot[_uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            _uiSlots[i].index = i;
            _uiSlots[i].ClearSlot();
        }

        _quickSlotInventory.Initalize();

        if (GameManager.Instance.playerManager.playerData.itemSlots != null)
        {
            Debug.Log("Inventory Data Load");
            slots = GameManager.Instance.playerManager.playerData.itemSlots;
            UpdateUI();

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.Type == "using")
                    {
                        _quickSlotInventory.AddItem(slots[i].item, slots[i].count);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Inventory Not");
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = new ItemSlot(); // 슬롯의 요소들을 ItemSlot의 인스턴스로 초기화
            }
        }


        ClearSeletecItemWindow(); //아이템 정보 보여주는 오브젝트 비활성
        QuestManager.OnQuestCleared += CloseInventory;

    }

    private void OnStatIconClick()
    {
        GameManager.Instance.uiManager.ShowPopupUI<PlayerStatusPopup>(parent: _playerStatIcon.transform);
    }

    private void ButtonEvent()
    {
        Button B_useBtn = useButton.GetComponent<Button>();
        Button B_equipBtn = equipButton.GetComponent<Button>();
        Button B_unEquipBtn = unEquipButton.GetComponent<Button>();
        Button B_dropBtn = dropButton.GetComponent<Button>();
        Button B_saleBtn = saleButton.GetComponent<Button>();
        Button B_checkBtn = checkBtn.GetComponent<Button>();
        Button B_saleCheckBtn = saleCheckBtn.GetComponent<Button>();
        Button B__saleCancleBtn = saleCancleBtn.GetComponent<Button>();
        B_useBtn.onClick.AddListener(OnUseButton);
        B_equipBtn.onClick.AddListener(OnEquipBtton);
        B_unEquipBtn.onClick.AddListener(OnUnEquipButton);
        B_dropBtn.onClick.AddListener(OnDropButton);
        B_saleBtn.onClick.AddListener(SaleItem);
        B_checkBtn.onClick.AddListener(OnInventoryCheckButton);
        B_saleCheckBtn.onClick.AddListener(OnSaleCheckButton);
        B__saleCancleBtn.onClick.AddListener(OnSaleCancelButton);
        menuRButton.onClick.AddListener(() =>
        {
            optionUI.SetActive(true);
            _inventoryUI.SetActive(false);
        });
        optionUI.GetComponent<OptionPopup>().OverrideCancelButtonEvent(CloseInventory);
        rightBtn.onClick.AddListener(OnNext);
        leftBtn.onClick.AddListener(OnPrev);
        exitBtn.onClick.AddListener(OnExit);
        sortBtn.onClick.AddListener(InventorySort);
        //trimBtn.onClick.AddListener(InventoryTrim);
        quantityInput.onValueChanged.AddListener(QuantityInput);

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

            if (!npcInteraction) // 대화중에는 인벤토리 안열리게
            {
                if (activated)
                {
                    OpenInventory();
                    _playerController.Input.enabled = false; //플레이어 활동 비활성
                    playerLight.SetActive(true);

                    _quickSlotInventory.altKeyPressed = true;

                }
                else
                {
                    CloseInventory();
                    _playerController.Input.enabled = true;
                    playerLight.SetActive(false);

                    _quickSlotInventory.altKeyPressed = false;
                }
            }
        }

    }
    public void OpenInventory()
    {
        var startIndex = (_currentPage - 1) * _maxSlot; // 시작 인덱스 0
        var endIndex = Mathf.Min(startIndex + _maxSlot, _uiSlots.Length); // 끝 인덱스 12

        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < _uiSlots.Length; i++)
        {
            _uiSlots[i].gameObject.SetActive(i >= startIndex && i < endIndex); // 0~11까지의 슬롯만 활성화
        }

        _inventoryUI.SetActive(true);
        activated = true;

        ClearSeletecItemWindow();
        Cursor.lockState = CursorLockMode.None; //마우스 커서 표시

        OnInventoryOpen?.Invoke(); // NPC G키 비활성화

    }

    public void CloseInventory()
    {
        _inventoryUI.SetActive(false);
        optionUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerLight.SetActive(false);
        _playerController.Input.enabled = true;
        OnInventoryClose.Invoke();

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
        Cursor.lockState = CursorLockMode.None;
        _playerController.Input.enabled = true;
        playerLight.SetActive(false);
        OnInventoryClose?.Invoke();
    }


    // -------------------------------------------------------------------------------

    //아이템 추가
    public void AddItem(Item _item, int _quantity)
    {
        if (_item.Type == "using" || _item.Type == "Etc" || _item.Type == "Quest") // 소모성 아이템은 수량 체크
        {
            for (int i = 0; i < _quantity; i++)
            {
                ItemSlot slotStack = GetItemStack(_item);
                if (slotStack != null)
                {
                    slotStack.count++;
                }
                else
                {
                    ItemSlot emptySlot = GetEmptySlot();
                    Debug.Log("emptySlot" + emptySlot);
                    if (emptySlot != null)
                    {
                        emptySlot.item = _item;
                        emptySlot.count = 1;
                    }
                    else
                    {
                        ThrowItem(_item);
                    }
                }
            }
        }
        else if (_item.Type == "Equip") // 장착 아이템은 수량 누적 x
        {
            for (int i = 0; i < _quantity; i++)
            {
                ItemSlot emptySlot = GetEmptySlot();
                if (emptySlot != null)
                {
                    emptySlot.item = _item;
                    emptySlot.count = 1;
                }
                else
                {
                    ThrowItem(_item);
                }
            }

        }
        if (QuestManager.I.currentQuest.QuestType == 3 || QuestManager.I.currentQuest.QuestType == 6)
        {
            QuestItemCheck(QuestManager.I.currentQuest.QuestItemID, QuestManager.I.currentQuest.QuestItemID2, QuestManager.I.currentQuest.GoalCount, QuestManager.I.currentQuest.GoalCount2);
        }
        UpdateUI();
        // 퀵슬롯에 자동 저장
        if (_item.Type == "using")
        {
            Inventory.instance._quickSlotInventory.AddItem(_item, _quantity);
        }

    }

    // 아이템 수량 추가
    private ItemSlot GetItemStack(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
                continue;
            if (slots[i].item.ItemID == _item.ItemID && slots[i].count < _item.MaxAmount)
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
            if (slots[i].item == null || slots[i].item.ItemID == 0)
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

        _statIcon.SetActive(true);

        string statText = "";

        // Determine stat information based on item type and ID
        switch (_selectedItem.item.Type)
        {
            case "using":
                statText = UsingAndEctItemStatText();
                break;
            case "Etc":
                statText = UsingAndEctItemStatText();
                break;
            case "Quest":
                statText = UsingAndEctItemStatText();
                break;
            case "Equip":
                statText = EquipItemStatText();
                break;
        }

        selectedItemStatText.text = statText;

        // 예시: 사용 버튼은 항상 활성화, 장착 버튼은 장착 가능한 경우에만 활성화되도록 설정
        useButton.SetActive(_selectedItem.item.Type == "using" || _selectedItem.item.Type == "Etc" || _selectedItem.item.Type == "Quest");
        equipButton.SetActive(_selectedItem.item.Type == "Equip" && !_uiSlots[_index].equipped);
        unEquipButton.SetActive(_selectedItem.item.Type == "Equip" && _uiSlots[_index].equipped);
        dropButton.SetActive(true);
        if (sale_Inventory == true && _selectedItem.item.Type != "Quest")
        {
            saleButton.SetActive(true);
        }

        //// 퀘스트 아이템은 판매, 버리기 비활성화
        //if (_selectedItem.item.Type != "Etc")
        //{
        //    dropButton.SetActive(true);
        //}
        //else
        //{
        //    dropButton.SetActive(false);
        //}

        //if (sale_Inventory == true && _selectedItem.item.Type != "Etc")
        //{
        //    saleButton.SetActive(true);
        //}
        //else
        //{
        //    saleButton.SetActive(false);
        //}

    }

    private string UsingAndEctItemStatText()
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
            case int id when id >= 12 && id <= 27:
                return "Etc";
            case int id when id >= 28 && id <= 33:
                return "Quest";
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
    public void ClearSeletecItemWindow()
    {
        _selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;

        _statIcon.SetActive(false);
        selectedItemStatText.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
        saleButton.SetActive(false);
    }

    public void UpdateUI() //UI 업데이트
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
                _uiSlots[i].Set(slots[i]);
            else
            {
                Debug.Log("EmtySlot");
                _uiSlots[i].ClearSlot();
            }
        }
    }

    // -------------------------------------------------------------------------------

    //현재 선택한 아이템 사용하기
    public void OnUseButton()
    {
        if (_selectedItem.item.Type == "using")
        {
            Debug.Log("ItemUse");
            _quickSlotInventory.RemoveItemByID(_selectedItem.item.ItemID, 1); // 퀵슬롯 아이템 삭제(사용한 갯수)
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
            RemoveSelectedItem(1); //인벤토리에서 아이템 삭제         

        }
        else if (QuestManager.I.currentQuest.QuestItemID == 16 && _selectedItem.item.Type == "Etc")
        {
            QuestManager.I.CheckCurrentQuest(_selectedItem.item.ItemID);
            RemoveSelectedItem(1);
        }

        else if (_selectedItem.item.Type == "Etc")
        {
            popUpUI.SetActive(true);
            checkBtn.SetActive(true);

            popUpText.text = "퀘스트에서만 \n 사용할 수 있습니다.";
        }




        InventoryTrim();
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

                UpdateUI();
                break;
            }
        }
    }

    // -------------------------------------------------------------------------------

    // 인벤토리 정렬 (버블 정렬) 아이템 수가 적어서 사용 / 많을 경우에 퀵 정렬
    public void InventorySort()
    {
        // 장착된 아이템 슬롯과 정보를 저장
        bool equipped = _uiSlots[curEquipIndex].equipped;
        ItemSlot equippedItem = slots[curEquipIndex];

        // 아이디 순으로 정렬
        for (int i = 0; i < slots.Length; i++)
        {
            for (int j = i + 1; j < slots.Length; j++)
            {
                // null이 아니고, 오름차순으로 정렬
                if (slots[i].item != null && slots[j].item != null &&
                    slots[i].item.ItemID > slots[j].item.ItemID)
                {
                    ItemSlot temp = slots[i];
                    slots[i] = slots[j];
                    slots[j] = temp;

                    // 만약 i나 j 중 하나가 장착된 아이템 슬롯일 경우
                    // 나머지 하나는 장착이 해제되어야 함
                    if (i == curEquipIndex)
                    {
                        curEquipIndex = j;
                        _uiSlots[i].equipped = false;
                    }
                    else if (j == curEquipIndex)
                    {
                        curEquipIndex = i;
                        _uiSlots[j].equipped = false;
                    }

                }
                // 수량 정렬 / 아이템의 아이디가 같을 때
                if (slots[i].item != null && slots[j].item != null &&
                    slots[i].item.ItemID == slots[j].item.ItemID && slots[i].count < slots[i].item.MaxAmount)
                {
                    int totalAmount = slots[i].count + slots[j].count;
                    slots[i].count = Mathf.Min(totalAmount, slots[i].item.MaxAmount);
                    slots[j].count = totalAmount - slots[i].count;
                    if (slots[j].count <= 0)
                    {
                        slots[j].item = null;

                    }
                }

            }
        }
        UpdateUI();

        // 장착된 아이템 슬롯과 정보를 다시 설정
        _uiSlots[curEquipIndex].equipped = equipped;
        slots[curEquipIndex] = equippedItem;

        if (_uiSlots[curEquipIndex].equipped)
        {
            _uiSlots[curEquipIndex]._outline.enabled = true;
        }

        // 선택된 아이템 정보를 업데이트
        SelectItem(_selectedItemIndex);
    }


    // 인벤토리 빈칸 채우기
    public void InventoryTrim()
    {
        //마지막 슬롯은 검사할 필요가 없기 때문에 -1
        for (int i = 0; i < slots.Length - 1; i++)
        {
            // 현재 슬롯이 비어있고 다음 슬롯에 아이템이 있다면
            if (slots[i].item == null && slots[i + 1].item != null)
            {
                // 현재 슬롯에 다음 슬롯의 아이템을 이동
                slots[i] = slots[i + 1];
                slots[i + 1] = new ItemSlot(); // 다음 슬롯을 비워줘야하기 때문에 초기화

                _uiSlots[i].equipped = _uiSlots[i + 1].equipped; // 현재 슬롯의 장착 정보 <- 다음 슬롯 장착 정보 넣기
                _uiSlots[i + 1].equipped = false; // 뒤에 슬롯은 장착 정보 해제
                _uiSlots[i + 1]._outline.enabled = false;
                if (i + 1 == curEquipIndex) // 뒤 슬롯이 현재 장착된 상태라면 인덱스 초기화
                {
                    curEquipIndex = i;
                }
            }
        }

        UpdateUI(); // UI 업데이트
        SelectItem(_selectedItemIndex);
    }


    // -------------------------------------------------------------------------------

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
        GameManager.Instance.playerManager.playerData.WeaponID = _selectedItem.item.ItemID;
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
        RemoveSelectedItem(1);
        InventoryTrim();
    }

    // 아이템 버리기
    private void ThrowItem(Item _item)
    {
        //Instantiate(_item.Prefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360f));

        Vector3 throwPosition = transform.position + transform.forward * Random.Range(1.5f, 2f); //앞으로 1.5~3 거리만큼

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

    // 현재 아이템 사용시 수량 감소 및 장착 된 무기는 해제
    public void RemoveSelectedItem(int quantity)
    {
        _selectedItem.count -= quantity;

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


    // -------------------------------------------------------------------------------

    public void QuantityInput(string text)
    {
        ItemNameText.text = _selectedItem.item.ItemName;

        if (!string.IsNullOrEmpty(text))
        {
            _currentQuantity = int.Parse(quantityInput.text);
            int totalPrice = (_selectedItem.item.Money / 2) * _currentQuantity;
            ItemNameText.text = _selectedItem.item.ItemName + " : $ " + totalPrice + "\n 50% 가격으로 판매";
            //if (_selectedItem.item.Type == "Etc")
            //{
            //    ItemNameText.text = _selectedItem.item.ItemName + " : $ " + totalPrice;
            //}
        }
        else
        {
            _currentQuantity = 0;
            text = string.Format("0");
        }
    }

    // 아이템 판매하기
    public void SaleItem()
    {
        QuantityInput(quantityInput.text);
        if (!_uiSlots[_selectedItemIndex].equipped)
        {
            salePopUpUI.SetActive(true);

        }
        else
        {
            salePopUpUI.SetActive(false);
            popUpUI.SetActive(true);
            checkBtn.SetActive(true);
            popUpText.text = "장착중인 무기는 \n 판매할 수 없습니다.";
        }
    }


    // 팝업 판매 확인 버튼
    public void OnSaleCheckButton()
    {
        QuantityInput(quantityInput.text);

        int totalPrice = (_selectedItem.item.Money / 2) * _currentQuantity;
        if (_selectedItem.count >= _currentQuantity)
        {
            GameManager.Instance.playerManager.playerData.Gold += totalPrice;
            CashUpdate();
            Shop.instance.cash.text = cash.text; //인벤토리 소지금 업데이트 후 상점 소지금 업데이트
            salePopUpUI.SetActive(false);
            RemoveSelectedItem(_currentQuantity);
            InventoryTrim();
            // 퀵슬롯설정창에만 있으면 퀵슬롯 설정창에서 삭제, 퀵슬롯에만 있으면 퀵슬롯에서 삭제, 둘다있으면 삭제갯수보다 많은 곳에서 삭제

            if (_selectedItem.item.Type == "using" || _selectedItem.item.Type == "Etc")
            {
                _quickSlotInventory.RemoveItemByID(_selectedItem.item.ItemID, _currentQuantity); // 퀵슬롯 아이템 삭제
            }

        }
        else
        {
            salePopUpUI.SetActive(false);
            popUpUI.SetActive(true);
            checkBtn.SetActive(true);

            popUpText.text = "해당 개수 내에서만 \n 판매 가능합니다.";
        }

    }

    // 팝업 판매 취소 버튼
    public void OnSaleCancelButton()
    {
        salePopUpUI.SetActive(false);
    }

    // 팝업 경고 확인 버튼(잠금 무기 또는 금액 부족 시)
    public void OnInventoryCheckButton()
    {
        salePopUpUI.SetActive(false);
        popUpUI.SetActive(false);
    }

    //---------------------------------------------------------------------------

    //public void QuestItemCheck(int itemID, int quantity)
    //{

    //    for (int i = 0; i < _uiSlots.Length; i++)
    //    {
    //        if (slots[i].item != null)
    //        {
    //            if (itemID == slots[i].item.ItemID && slots[i].count >= quantity)
    //            {
    //                if (QuestManager.I.currentQuest.QuestType != 6)
    //                {
    //                    slots[i].count -= quantity;
    //                    if (slots[i].count <= 0)
    //                        slots[i].item = null;
    //                }
    //                QuestManager.I.QuestClear();

    //            }
    //        }
    //    }
    //}

    private void OnDestroy()
    {
        QuestManager.OnQuestCleared -= CloseInventory;
    }

    public void QuestItemCheck(int itemID1, int itemID2, int quantity1, int quantity2)
    {
        bool item1Processed = false;
        bool item2Processed = false;

        for (int i = 0; i < _uiSlots.Length; i++)
        {
            if (!item1Processed && slots[i].item != null && itemID1 == slots[i].item.ItemID && slots[i].count >= quantity1)
            {
                item1Processed = true;
            }

            if (!item2Processed && slots[i].item != null && itemID2 == slots[i].item.ItemID && slots[i].count >= quantity2)
            {
                item2Processed = true;
            }
        }

        if (item1Processed && (item2Processed || itemID2 == 0 && quantity2 == 0))
        {
            for (int i = 0; i < _uiSlots.Length; i++)
            {
                if (slots[i].item != null && itemID1 == slots[i].item.ItemID && slots[i].count >= quantity1)
                {
                    if(QuestManager.I.currentQuest.QuestType != 6)
                    {
                        slots[i].count -= quantity1;
                        if (slots[i].count <= 0)
                        {
                            slots[i].item = null;
                        }
                    }                    
                }

                if (slots[i].item != null && itemID2 == slots[i].item.ItemID && slots[i].count >= quantity2)
                {
                    if (QuestManager.I.currentQuest.QuestType != 6)
                    {
                        slots[i].count -= quantity1;
                        if (slots[i].count <= 0)
                        {
                            slots[i].item = null;
                        }
                    }
                }
            }
            QuestManager.I.QuestClear();
        }
    }


}

