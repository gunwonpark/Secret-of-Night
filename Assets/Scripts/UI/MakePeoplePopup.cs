using UnityEngine;
using UnityEngine.UI;

public class MakePeoplePopup : UIBase
{
    [SerializeField] private Image _background;
    bool _isEnd = false;
    private void Awake()
    {
        _background.rectTransform.localPosition = new Vector3(0, -1920 + transform.position.y, 0);
    }
    void Update()
    {
        if (_isEnd == false)
        {
            _background.rectTransform.localPosition += new Vector3(0, 1000 * Time.deltaTime, 0);
            if (_background.transform.localPosition.y >= 850f + transform.position.y)
            {
                // Stop scrolling or reset position
                _isEnd = true;
            }
        }
    }
}
