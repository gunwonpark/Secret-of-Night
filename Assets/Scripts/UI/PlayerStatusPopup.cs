using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusPopup : UIBase
{
    [Header("PlayerStatus")]
    [SerializeField] private Image _playerHPImage;
    [SerializeField] private Image _playerMPImage;
    [SerializeField] private Image _playerExpImage;
    [SerializeField] private TextMeshProUGUI _playerHPText;
    [SerializeField] private TextMeshProUGUI _playerMPText;
    [SerializeField] private TextMeshProUGUI _playerExpText;
    [SerializeField] private TextMeshProUGUI _playerLevelText;
    [SerializeField] private TextMeshProUGUI _playerAttackText;
    [SerializeField] private TextMeshProUGUI _playerDefenseText;
    [SerializeField] private Button _quitButton;

    //캐싱
    PlayerGameData playerData;
    void Start()
    {
        playerData = GameManager.Instance.playerManager.playerData;

        playerData.OnHPChange += UpdateHP;
        playerData.OnMPChange += UpdateMP;
        playerData.OnExpChange += UpdateExp;
        playerData.OnLevelUp += UpdateLevel;
        _quitButton.onClick.AddListener(OnQuitButtonClick);

        UpdateUI();
    }

    private void OnQuitButtonClick()
    {
        Destroy(gameObject);
    }

    private void UpdateLevel()
    {
        _playerLevelText.text = $"{playerData.Level}";
    }

    private void UpdateHP()
    {
        _playerHPImage.fillAmount = playerData.CurHP / playerData.MaxHP;
        _playerHPText.text = $"{playerData.CurHP} / {playerData.MaxHP}";
    }
    private void UpdateMP()
    {
        _playerMPImage.fillAmount = playerData.CurMP / playerData.MaxMP;
        _playerMPText.text = $"{playerData.CurMP} / {playerData.MaxMP}";
    }
    private void UpdateExp()
    {
        _playerExpImage.fillAmount = playerData.CurExp / playerData.MaxExp;
        _playerExpText.text = $"{playerData.CurExp} / {playerData.MaxExp}";
    }
    private void UpdateAttack()
    {
        _playerAttackText.text = $"{playerData.Damage}";
    }
    private void UpdateDefense()
    {
        _playerDefenseText.text = $"{playerData.Def}";
    }
    void UpdateUI()
    {
        UpdateHP();
        UpdateMP();
        UpdateExp();
        UpdateLevel();
        UpdateAttack();
        UpdateDefense();
    }
    private void OnDestroy()
    {
        playerData.OnHPChange -= UpdateHP;
        playerData.OnMPChange -= UpdateMP;
        playerData.OnExpChange -= UpdateExp;
        playerData.OnLevelUp -= UpdateLevel;
    }
}
