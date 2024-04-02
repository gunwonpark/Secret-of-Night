using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public bool shopActivated;

    [SerializeField] private ShopSlot[] _uiSlots; // 상점 슬롯들을 저장할 배열
    [SerializeField] private Item[] _items; // 상점에 판매할 아이템 데이터 배열

    private CameraHandler _camera;
    private PlayerController _playerController;

    [Header("Shop UI")]
    [SerializeField] private GameObject _shopUI;
    [SerializeField] private GameObject _slotGrid;

    [Header("Selected Item")]
    [SerializeField] private GameObject _statInfo; // 스탯 정보 
    private ShopSlot _selectedItem;
    private int _selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatText;

    [Header("Page")]
    // 페이지 넘기기 위한 변수
    private int _maxSlot = 12;
    private int _currentPage = 1;
    private int _totalPage = 3;

    public Button rightBtn;
    public Button leftBtn;

    [Header("Cash")]
    public TextMeshProUGUI cash;
    public GameObject purchaseBtn;

    [Header("PurchasePop-Up")]
    public GameObject purchasePopUpUI;
    public TMP_InputField countInput;
    public GameObject purchaseCheckBtn;
    public GameObject purchaseCancleBtn;
    public TextMeshProUGUI ItemNameText;

    [Header("Pop-Up")]
    public GameObject popUpUI;
    public GameObject checkBtn;
    public TextMeshProUGUI popUpText;


    private void Awake()
    {
        instance = this;
        _camera = FindObjectOfType<CameraHandler>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        _shopUI.SetActive(false);
        _statInfo.SetActive(false);
        popUpUI.SetActive(false);

        _uiSlots = _slotGrid.GetComponentsInChildren<ShopSlot>();

        // 각 상점 슬롯에 아이템 불러오기
        _items = GameManager.Instance.dataManager.itemDataBase.GetAllItems().ToArray();

        // 아이템 목록에서 8번째 아이템 제외 (기본아이템)
        _items = RemoveItemIndex(_items, 7);

        for (int i = 0; i < _uiSlots.Length; i++)
        {
            // 상점 슬롯에 아이템 넣기
            if (i < _items.Length)
            {
                _uiSlots[i].ShopSetItem(_items[i]);
                LockItem();
            }
            else
            {
                // 빈 아이템으로 슬롯 설정
                _uiSlots[i].ShopClearSlot();
            }
        }

        for (int i = 0; i < _uiSlots.Length; i++)
        {
            _uiSlots[i].shopIndex = i;
        }

        ClearSeletecItemWindow();
        cash.text = Inventory.instance.cash.text; //돈

    }

    //기본 아이템 제외 
    private Item[] RemoveItemIndex(Item[] _array, int _index)
    {
        Item[] newArray = new Item[_array.Length - 1]; // 아이템 10개 중 기본 아이템 1개 뺀 길이

        int newIndex = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (i != _index) // 기본 아이템 8번 제외하고 배열에 저장 (인덱스는 7번임)
            {
                newArray[newIndex] = _array[i];
                newIndex++;
            }
        }
        return newArray;
    }

    void Update()
    {
        OpenShopUI();
    }

    private void OpenShopUI()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            shopActivated = !shopActivated;

            if (shopActivated)
            {
                if (Inventory.instance.activated)
                {
                    Inventory.instance.CloseInventory();
                    Inventory.instance.playerLight.SetActive(false);
                }
                OpenShop();
                _camera.enabled = false; // 카메라 비활성
                _playerController.Input.enabled = false; //플레이어 활동 비활성

            }
            else
            {
                CloseShop();
                _camera.enabled = true;
                _playerController.Input.enabled = true;
            }
        }
    }

    private void OpenShop()
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
        _shopUI.SetActive(true);
    }

    public void CloseShop()
    {
        _shopUI.SetActive(false);
    }

    // 다음 슬롯 창
    private void NextPage()
    {
        if (_currentPage == _totalPage) // 현재 페이지가 총 페이지와 같을 경우 리턴
        {
            return;
        }
        _currentPage++;

        //(0~11, 12~23, 24~35번 슬롯)
        var startIndex = (_currentPage - 1) * _maxSlot;
        var endIndex = Mathf.Min(startIndex + _maxSlot, _uiSlots.Length);

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
        _shopUI.SetActive(false);
        _camera.enabled = true;
        _playerController.Input.enabled = true;
    }

    //아이템 슬롯 선택시 아이템 설명이 보이게
    public void SelectItem(int index)
    {
        if (_uiSlots[index].item == null)
        {
            return;
        }
        _selectedItem = _uiSlots[index];
        _selectedItemIndex = index;
        selectedItemName.text = _selectedItem.item.ItemName;
        selectedItemDescription.text = _selectedItem.item.Description;
        purchaseBtn.SetActive(true);

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

    private void ClearSeletecItemWindow()
    {
        _selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        purchaseBtn.SetActive(false);

        _statInfo.SetActive(false);
        selectedItemStatText.text = string.Empty;

    }

    //아이템 잠금
    private void LockItem()
    {
        for (int i = 0; i < _uiSlots.Length; i++)
        {
            //item 배열의 길이를 넘지 않는 내에서 접근 가능하게
            if (i < _items.Length && GameManager.Instance.playerManager.playerData.Level <= _items[i].UnlockLevel)
            {
                _uiSlots[i].LockImage(1);
                _uiSlots[i].IsLocked = true;
            }
            else
            {
                _uiSlots[i].LockImage(0);
                _uiSlots[i].IsLocked = false;
            }
        }
    }
    public void UnLockItem()
    {
        for (int i = 0; i < _uiSlots.Length; i++)
        {
            //item 배열의 길이를 넘지 않는 내에서 접근 가능하게
            if (i < _items.Length && GameManager.Instance.playerManager.playerData.Level <= _items[i].UnlockLevel)
            {
                _uiSlots[i].LockImage(0);
                _uiSlots[i].IsLocked = true;
            }

        }
    }

    // 아이템 구매 
    public void PurchaseItem()
    {
        if (_selectedItem != null && !_selectedItem.IsLocked) // 잠기지 않은 아이템만 구매 가능하도록
        {
            if (GameManager.Instance.playerManager.playerData.Gold >= _selectedItem.item.Money)
            {
                purchasePopUpUI.SetActive(true); // 구매 팝업
                ItemNameText.text = _selectedItem.item.ItemName + " : $ " + _selectedItem.item.Money;

            }
            else
            {
                popUpUI.SetActive(true); // 일반 팝업
                popUpText.text = "소지금이 부족합니다.";
            }
        }
        else
        {
            popUpUI.SetActive(true);
            popUpText.text = "잠금 아이템 입니다.\n 권장 레벨 :" + _selectedItem.item.UnlockLevel;
        }
    }


    // 팝업 구매 확인 버튼
    public void OnPurchaseCheckButton()
    {
        GameManager.Instance.playerManager.playerData.Gold -= _selectedItem.item.Money;
        Inventory.instance.AddItem(_selectedItem.item);
        Inventory.instance.CashUpdate(); // 차감된 돈 인벤토리에 업데이트
        cash.text = Inventory.instance.cash.text; // 상점 돈도 업데이트

        purchasePopUpUI.SetActive(false);
        ItemNameText.text = "";
    }

    // 팝업 구매 취소 버튼
    public void OnPurchaseCancelButton()
    {
        purchasePopUpUI.SetActive(false);
        ItemNameText.text = "";
    }


    // 팝업 경고 확인 버튼(잠금 무기 또는 금액 부족 시)
    public void OnShopCheckButton()
    {
        popUpUI.SetActive(false);
        popUpText.text = "";
    }
}
