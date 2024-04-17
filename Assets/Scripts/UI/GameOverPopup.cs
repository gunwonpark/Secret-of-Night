using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPopup : UIBase
{
    [SerializeField] private Button _returnToMainButton;

    void Start()
    {
        _returnToMainButton.onClick.AddListener(() => SceneManager.LoadScene("GameStartScene"));
    }
}
