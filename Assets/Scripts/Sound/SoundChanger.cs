using UnityEngine;

public class SoundChanger : MonoBehaviour
{
    [SerializeField] private AudioClip _enterBgm;
    [SerializeField] private AudioClip _exitBgm;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.soundManager.PlayBGM(_enterBgm);

    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.soundManager.PlayBGM(_exitBgm);
    }

}
