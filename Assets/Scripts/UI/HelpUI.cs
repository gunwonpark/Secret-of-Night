using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HelpUI : MonoBehaviour, IPointerClickHandler
{
    public Button InvenIcon;
    public Button HelpIcon;

    public GameObject HelpUi;
    public GameObject InvenUi;
    public GameObject GameUi;

    private QuickSlotInventory _quickInventory;

    void Start()
    {
        //InvenIcon.onClick.AddListener(Inven);
        HelpIcon.onClick.AddListener(Help);
        _quickInventory = GameUi.GetComponentInChildren<QuickSlotInventory>();
    }

    void Help()
    {
        HelpUi.SetActive(true);
        Debug.Log(_quickInventory.altKeyPressed);
    }

    //void Inven()
    //{
    //    Inventory.instance.OpenInventory();
    //    Inventory.instance._playerController.Input.enabled = false; //플레이어 활동 비활성
    //    Inventory.instance.playerLight.SetActive(true);

    //    HelpUi.gameObject.SetActive(false);

    //    Debug.Log(_quickInventory.altKeyPressed);
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HelpUi.SetActive(false);
            //_quickInventory.altKeyPressed = false;
        }

        Debug.Log(_quickInventory.altKeyPressed);
    }
}
