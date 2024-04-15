using UnityEngine;
using UnityEngine.UI;

public class OptionPopup : MonoBehaviour
{
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
    }

    void OnClickVolumeRightButton()
    {
        _masterVolumeImage.fillAmount += 0.1f;
        GameManager.Instance.soundManager.SetMasterVolume(_masterVolumeImage.fillAmount);
    }
}
