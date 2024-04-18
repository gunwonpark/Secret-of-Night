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

    private void Start()
    {
        Debug.Log("LoadingUI");
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


            if (timer >= 1.0f)
            {
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }
}
