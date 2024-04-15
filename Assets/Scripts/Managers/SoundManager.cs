using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _bgm;
    public void SetMasterVolume(float volume)
    {
        _audioMixer.SetFloat("Master", 20 * Mathf.Log10(volume));
    }
    public void PlayBGM(AudioClip bgm)
    {
        _bgm.clip = bgm;
        _bgm.loop = true;
        _bgm.volume = 1.0f;
        _bgm.Play();
    }
}
