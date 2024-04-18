using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MakePeoplePopup : UIBase
{
    [SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private float _time = 2f;
    [SerializeField] private float _speed = 300f;
    private bool _isEnd = false;
    private void Awake()
    {
        _background.rectTransform.localPosition = new Vector3(0, -1920 + transform.position.y, 0);
        _isEnd = false;
    }

    void Update()
    {
        if (_isEnd == false)
        {
            _background.rectTransform.localPosition += new Vector3(0, _speed * Time.deltaTime, 0);
            if (_background.transform.localPosition.y >= 850f + transform.position.y)
            {
                _isEnd = true;
                FadeOut(_time);
            }
        }
    }
    void FadeOut(float time)
    {
        _background.CrossFadeAlpha(0, time, false);
        _name.CrossFadeAlpha(0, time, false);
        Destroy(gameObject, time);
    }
}
