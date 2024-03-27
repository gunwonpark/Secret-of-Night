using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopSlot[] _slots; // 상점 슬롯들을 저장할 배열
    [SerializeField] private Item[] _items; // 상점에 판매할 아이템 데이터 배열

    private bool _activated;

    private CameraHandler _camera;
    private PlayerController _playerController;

    [SerializeField] private GameObject _shopUI;
    [SerializeField] private GameObject _slotGrid;

    // 페이지 넘기기 위한 변수
    private int _maxSlot = 12;
    private int _currentPage = 1;
    private int _totalPage = 3;

    public Button rightBtn;
    public Button leftBtn;

    private void Awake()
    {
        _camera = FindObjectOfType<CameraHandler>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        _slots = GetComponentsInChildren<ShopSlot>();

        _shopUI.SetActive(false);
        // 각 상점 슬롯에 아이템 불러오기
        _items = GameManager.Instance.dataManager.itemDataBase.GetAllItems().ToArray();

        // 아이템 목록에서 8번째 아이템 제외 (기본아이템)
        _items = RemoveItemAtIndex(_items, 7);

        for (int i = 0; i < _slots.Length; i++)
        {
            // 상점 슬롯에 아이템을 설정
            if (i < _items.Length)
            {
                _slots[i].ShopSetItem(_items[i]);
            }
            else
            {
                // 빈 아이템으로 슬롯 설정
                _slots[i].ShopClearSlot();
            }
        }
    }

    private Item[] RemoveItemAtIndex(Item[] _array, int _index)
    {
        Item[] newArray = new Item[_array.Length - 1];

        int newIndex = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (i != _index)
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
            _activated = !_activated;

            if (_activated)
            {
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
        var endIndex = Mathf.Min(startIndex + _maxSlot, _slots.Length); // 끝 인덱스 12

        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].gameObject.SetActive(i >= startIndex && i < endIndex); // 0~11까지의 슬롯만 활성화
        }

        //마우스 커서 표시
        Cursor.lockState = CursorLockMode.None;
        _shopUI.SetActive(true);
    }

    private void CloseShop()
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
        var endIndex = Mathf.Min(startIndex + _maxSlot, _slots.Length);

        // 현재 페이지에 있는 슬롯만 활성화 (1~12개)
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
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
        var endIndex = Mathf.Min(startIndex + _maxSlot, _slots.Length);

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].gameObject.SetActive(i >= startIndex && i < endIndex);
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
}
