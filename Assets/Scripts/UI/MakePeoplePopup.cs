using UnityEngine;
using UnityEngine.UI;

public class MakePeoplePopup : UIBase
{
    [SerializeField] private Image _background;
    bool _isEnd = false;
    private void Start()
    {
        _background.rectTransform.position = new Vector3(transform.position.x, -1920, transform.position.z);
    }
    void Update()
    {
        if (_isEnd == false)
        {
            _background.rectTransform.position += new Vector3(0, 100 * Time.deltaTime, 0);
            if (transform.localPosition.y >= 875f)
            {
                // Stop scrolling or reset position
                _isEnd = true;
            }
        }
    }
}
