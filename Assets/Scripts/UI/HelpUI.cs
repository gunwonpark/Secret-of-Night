using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HelpUI : MonoBehaviour, IPointerClickHandler
{
    public Button InvenIcon;
    public Button HelpIcon;

    public GameObject HelpUi;

    void Start()
    {
        //InvenIcon.onClick.AddListener(Inven);
        HelpIcon.onClick.AddListener(Help);
    }

    void Help()
    {
        HelpUi.SetActive(true);
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
        }

    }
}
