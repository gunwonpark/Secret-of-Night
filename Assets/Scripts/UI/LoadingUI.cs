using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingUI : UIBase
{
    [SerializeField] TextMeshProUGUI _tipText;
    [SerializeField] string[] _tipTexts;
    [SerializeField] Image _loadingImage;

    [SerializeField] private float _leastWaitTime = 1.5f;
    [SerializeField] private float _rotationSpeed = 360f;  // Rotation speed in degrees per second
    private void Start()
    {
        StartCoroutine(LoadScene());
        if (_tipTexts.Length != 0)
        {
            int randomTip = Random.Range(0, _tipTexts.Length);
            _tipText.text = _tipTexts[randomTip];
        }
        else
        {
            _tipText.text = "후에엥";
        }
    }
    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync((int)GameManager.Instance.sceneManager.NextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            _loadingImage.transform.Rotate(new Vector3(0, 0, _rotationSpeed) * Time.deltaTime);

            if (timer >= _leastWaitTime)
            {
                op.allowSceneActivation = true;
            }
        }
    }
}
