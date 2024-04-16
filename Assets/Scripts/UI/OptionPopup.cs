using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionPopup : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Volume")]
    [SerializeField] private Button _masterVolumeLeftButton;
    [SerializeField] private Button _masterVolumeRightButton;
    [SerializeField] private Button _bgmVolumeLeftButton;
    [SerializeField] private Button _bgmVolumeRightButton;
    [SerializeField] private Button _sfxVolumeLeftButton;
    [SerializeField] private Button _sfxVolumeRightButton;

    [SerializeField] private Image _masterVolumeImage;
    [SerializeField] private Image _bgmVolumeImage;
    [SerializeField] private Image _sfxVolumeImage;

    private void Start()
    {
        _masterVolumeRightButton.onClick.AddListener(OnClickVolumeRightButton);
        _masterVolumeLeftButton.onClick.AddListener(OnClickVolumeLeftButton);
        _masterVolumeImage.fillAmount = 0f;
        SetMasterVolume(Remap(_masterVolumeImage.fillAmount));
    }

    void OnClickVolumeRightButton()
    {
        _masterVolumeImage.fillAmount += 0.1f;
        SetMasterVolume(Remap(_masterVolumeImage.fillAmount));
    }
    void OnClickVolumeLeftButton()
    {
        _masterVolumeImage.fillAmount -= 0.1f;
        SetMasterVolume(Remap(_masterVolumeImage.fillAmount));
    }
    public void SetMasterVolume(float volume)
    {
        //0.0001 ~ 10 까지
        _audioMixer.SetFloat("Master", 20 * Mathf.Log10(volume + 0.001f));
        Debug.Log(20 * Mathf.Log10(volume));
    }

    float Remap(float value, float minValue = 0.0001f, float maxValue = 10f)
    {
        return value * (1 - minValue) + minValue;
    }
}
