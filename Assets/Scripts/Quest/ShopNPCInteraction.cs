using TMPro;
using UnityEngine;

public class ShopNPCInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.G; // 상호작용 키
    [SerializeField] private GameObject interactionPopup; // 팝업 창
    [SerializeField] private int questID; // 퀘스트 ID

    public GameObject talkBtn;
    public GameObject tradeBtn;
    public GameObject buyBtn;
    public GameObject saleBtn;

    public TextMeshProUGUI talktext;

    private Shop _shop;

    private bool isInRange = false; // 플레이어가 일정 범위 내에 있는지 여부
    private bool _activate = true; // 대화, 구매, 판매시 G키 비활성화 시키게


    void Start()
    {
        _shop = GetComponent<Shop>();
        Inventory.OnInventoryClose += OnInventoryClosed;
        Shop.OnShopClose += OnShopClose;
    }
    private void Update()
    {
        if (Input.GetKeyDown(interactionKey) && isInRange && _activate)
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

        talkBtn.SetActive(true);
        tradeBtn.SetActive(true);
        buyBtn.SetActive(false);
        saleBtn.SetActive(false);
        talktext.text = "안녕! 주인공! 오늘은 무슨 일로 왔어?";

        Cursor.lockState = CursorLockMode.None;
    }

    // 팝업 창에서 호출되는 메서드 (예: '닫기' 버튼을 눌렀을 때)
    public void CloseInteractionPopup()
    {
        // 팝업 창을 비활성화하여 가리기
        interactionPopup.SetActive(false);
        _activate = false;
    }

    // 대화 버튼을 눌렀을때 호출되는 메서드
    public void Dialogue()
    {
        QuestManager.I.CheckCurrentQuest(questID); // 현재 퀘스트 확인
        if (QuestManager.I.currentQuest.questID == questID)
        {
            interactionPopup.SetActive(false);
        }
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
        interactionPopup.SetActive(false);
        Inventory.instance._playerController.Input.enabled = false; //플레이어 활동 비활성
        _shop.shopActivated = true;

        _activate = false;
    }

    public void OnSaleClick()
    {
        Inventory.instance.OpenInventory();
        interactionPopup.SetActive(false);
        Inventory.instance._playerController.Input.enabled = false; //플레이어 활동 비활성
        Inventory.instance.activated = true;

        _activate = false;
    }

    private void OnInventoryClosed()
    {
        // 인벤토리가 닫힐 때 _activate 변수 다시 활성화
        _activate = true;
    }

    private void OnShopClose()
    {
        _activate = true;
    }

}
