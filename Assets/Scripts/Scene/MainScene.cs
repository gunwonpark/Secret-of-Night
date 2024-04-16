using UnityEngine;

public class MainScene : MonoBehaviour
{
    [SerializeField] private AudioClip _bgm;

    private void Start()
    {
        GameManager.Instance.soundManager.PlayBGM(_bgm);
    }
}
