using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopNPCInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.G; // 상호작용 키
    [SerializeField] private GameObject interactionPopup; // 팝업 창
    [SerializeField] private int questID; // 퀘스트 ID

    public GameObject talkBtn;
    public GameObject tradeBtn;
    public GameObject buyBtn;
    public GameObject saleBtn;
    public Button exitBtn;

    public TextMeshProUGUI talktext;

    private Shop _shop;

    private bool isInRange = false; // 플레이어가 일정 범위 내에 있는지 여부
    private bool _GKeyActivate = true; // 대화, 구매, 판매시 G키 비활성화 시키게

    void Start()
    {
        _shop = GetComponent<Shop>();
        Inventory.OnInventoryOpen += OnInventoryOpen;
        Inventory.OnInventoryClose += OnInventoryClosed;
        Shop.OnShopClose += OnShopClose;

        ButtonEvent();
    }
    private void Update()
    {
        if (Input.GetKeyDown(interactionKey) && isInRange && _GKeyActivate)
        {
            OpenInteractionPopup();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void OpenInteractionPopup()
    {
        // 팝업 창을 활성화하여 보이게 함
        interactionPopup.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Inventory.instance.npcInteraction = true;

        talkBtn.SetActive(true);
        tradeBtn.SetActive(true);
        buyBtn.SetActive(false);
        saleBtn.SetActive(false);
        talktext.text = "안녕! 주인공! 오늘은 무슨 일로 왔어?";

    }

    // 팝업 창에서 호출되는 메서드 (예: '닫기' 버튼을 눌렀을 때)
    public void CloseInteractionPopup()
    {
        // 팝업 창을 비활성화하여 가리기
        interactionPopup.SetActive(false);
        Inventory.instance.npcInteraction = false;
        _GKeyActivate = true;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // 대화 버튼을 눌렀을때 호출되는 메서드
    public void Dialogue()
    {         
        if (QuestManager.I.currentQuest.QuestID == questID)
        {
            QuestManager.I.CheckCurrentQuest(questID);
            interactionPopup.SetActive(false);
        }
    }

    private void ButtonEvent()
    {
        Button B_talkBtn = talkBtn.GetComponent<Button>();
        Button B_tradeBtn = tradeBtn.GetComponent<Button>();
        Button B_buyBtn = buyBtn.GetComponent<Button>();
        Button B_saleBtn = saleBtn.GetComponent<Button>();
        //B_talkBtn.onClick.AddListener()
        B_tradeBtn.onClick.AddListener(OnTradeClick);
        B_buyBtn.onClick.AddListener(OnBuyClick);
        B_saleBtn.onClick.AddListener(OnSaleClick);
        exitBtn.onClick.AddListener(CloseInteractionPopup);

    }
    public void OnTradeClick()
    {
        talktext.text = "거래? 구매할래 판매할래?";
        talkBtn.SetActive(false);
        tradeBtn.SetActive(false);
        buyBtn.SetActive(true);
        saleBtn.SetActive(true);
    }

    public void OnBuyClick()
    {
        _shop.OpenShop();
        Cursor.lockState = CursorLockMode.None;  //마우스 커서 표시
        interactionPopup.SetActive(false);
        Inventory.instance._playerController.Input.enabled = false; //플레이어 활동 비활성
        _shop.shopActivated = true;
        _GKeyActivate = false;
    }

    public void OnSaleClick()
    {
        Inventory.instance.OpenInventory();
        Cursor.lockState = CursorLockMode.None;
        interactionPopup.SetActive(false);
        Inventory.instance._playerController.Input.enabled = false; //플레이어 활동 비활성
        Inventory.instance.activated = true;
        Inventory.instance.sale_Inventory = true; //판매하는 인벤토리 활성화
        _GKeyActivate = false;
    }

    //------------------------------------------------
    // _GKeyActivate는 인벤토리 또는 상점이 열려있을 때 대화창이 활성화 되지 않게 
    private void OnInventoryOpen()
    {
        _GKeyActivate = false;
    }
    private void OnInventoryClosed()
    {
        // 인벤토리가 닫힐 때 _activate 변수 다시 활성화
        _GKeyActivate = true;
        Inventory.instance.npcInteraction = false;
        Inventory.instance.sale_Inventory = false;
    }

    private void OnShopClose()
    {
        _GKeyActivate = true;
        Inventory.instance.npcInteraction = false;
    }

}
