using UnityEngine;
using UnityEngine.UI;

public class GameOverPopup : UIBase
{
    [SerializeField] private Button _returnToMainButton;

    void Start()
    {
        _returnToMainButton.onClick.AddListener(() => GameManager.Instance.sceneManager.LoadSceneAsync(Scene.GameStart));
    }
}
