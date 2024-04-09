using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartUI : UIBase
{
    // 나중에 통합해야됨
    private string _jsonDataPath = $"{Application.dataPath}/Datas/PlayerData_";

    private bool[] savefile;


    [Header("GameButton")]
    [SerializeField] private Button _gameStartButton;
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _makePeopleButton;
    [SerializeField] private Button _gameEndButton;

    [Header("Option")]
    [SerializeField] private Button _optionButton;

    public void Start()
    {
        Initialize();
    }
    public override void Initialize()
    {
        base.Initialize();

        // 초기 화면에서 하는것이 좋을거 같다
        for (int slotNumber = 0; slotNumber < 5; slotNumber++)
        {
            if (File.Exists(_jsonDataPath + $"{slotNumber}"))
            {

                GameManager.Instance.playerManager.playerDatas.Add(slotNumber, new PlayerGameData());
                GameManager.Instance.playerManager.playerDatas[slotNumber].SlotNumber = slotNumber;
                GameManager.Instance.playerManager.playerDatas[slotNumber].Initialize();
            }
        }
        // 데이터가 있는경우 이어하기 및 불러오기
        if (GameManager.Instance.playerManager.playerDatas != null)
        {
            _loadButton.gameObject.SetActive(true);
            _continueButton.gameObject.SetActive(true);
            _loadButton.onClick.AddListener(OnLoadButtonClick);

        }
        else
        {
            // 데이터가 없는경우 게임 시작 Button
            _gameStartButton.gameObject.SetActive(true);
            _gameStartButton.onClick.AddListener(OnGameStartButtonClick);

        }
    }
    void OnGameStartButtonClick()
    {
        GameManager.Instance.playerManager.Initialize(1);
        SceneManager.LoadScene("MainScene");
    }
    void OnLoadButtonClick()
    {
        GameManager.Instance.uiManager.ShowPopupUI<LoadPopup>("LoadPopup");
    }
    void OnContinueButtonClick()
    {

    }
}
