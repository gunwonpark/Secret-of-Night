using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartUI : UIBase
{
    // 나중에 통합해야됨
    private string _jsonDataPath = $"{Application.dataPath}/Datas/PlayerData";

    // 불러오기 용 데이터
    private string data;

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
        // 데이터가 없는경우 게임 시작 Button
        if (File.Exists(_jsonDataPath))
        {
            data = File.ReadAllText(_jsonDataPath);
            if (data != "")
            {
                _loadButton.gameObject.SetActive(true);
                _continueButton.gameObject.SetActive(true);
                return;
            }
        }

        // 데이터가 있는경우 이어하기 및 불러오기
        _gameStartButton.gameObject.SetActive(true);
        _gameStartButton.onClick.AddListener(OnGameStartButtonClick);
    }
    void OnGameStartButtonClick()
    {
        GameManager.Instance.playerManager.playerData.Initialize(1);
        SceneManager.LoadScene("MainScene");
    }
    void OnLoadButtonClick()
    {

    }
    void OnContinueButtonClick()
    {

    }
}
