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
    public void PlayBGM(AudioClip bgm, float volume = 1f)
    {
        _bgm.clip = bgm;
        _bgm.loop = true;
        _bgm.volume = volume;
        _bgm.Play();
    }
}
