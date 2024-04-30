using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HelpUI : MonoBehaviour, IPointerClickHandler
{
    public Button InvenIcon;
    public Button HelpIcon;
    public Button SaveIcon;

    public GameObject HelpUi;
    private int maxCount = 1;

    void Start()
    {
        //InvenIcon.onClick.AddListener(Inven);
        HelpIcon.onClick.AddListener(Help);
        SaveIcon.onClick.AddListener(Save);
    }

    private void Save()
    {
        GameManager.Instance.uiManager.ShowPopupUI<SavePopup>();
    }

    void Help()
    {
        HelpUi.SetActive(true);
    }

    //void StartHelp()
    //{
    //    HelpUi.SetActive(true);
    //    StartCoroutine("CloseUI");
    //}

    private void Update()
    {
        if (QuestManager.I.currentQuest.QuestID == 1001 && DialogueHandler.I.dialogueIndex == 4)
        {
            for (int i = 0; i < maxCount; i++)
            {
                maxCount--;
                Help();
            }          
        }
    }

    //IEnumerator CloseUI()
    //{
    //    yield return new WaitForSecondsRealtime(3f);
    //    HelpUi.SetActive(false);
    //}


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
