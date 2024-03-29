using UnityEngine;
using UnityEngine.UI;

public class TestLevelUp : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(LevelUP);
    }

    private void LevelUP()
    {
        GameManager.Instance.playerManager.playerData.LevelUp();
    }
}
