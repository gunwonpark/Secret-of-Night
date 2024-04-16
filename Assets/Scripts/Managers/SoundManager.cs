using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bgm;
    public void Initialize()
    {
        GameObject root = new GameObject("SoundRoot");
        DontDestroyOnLoad(root);
        _bgm = Instantiate(Resources.Load<AudioSource>("Prefabs/Sound/BGM"));
        _bgm.transform.parent = root.transform;
    }
    public void PlayBGM(AudioClip bgm)
    {
        _bgm.clip = bgm;
        _bgm.loop = true;
        _bgm.volume = 1.0f;
        _bgm.Play();
    }
}
