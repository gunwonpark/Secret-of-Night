using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : MonoBehaviour
{
    public BaseScene CurrentScene;

    //비동기 씬전환 목적
    public Scene NextScene;
    public void LoadSceneAsync(Scene sceneType)
    {
        Clear();
        NextScene = sceneType;
        SceneManager.LoadScene((int)Scene.Loading);

    }
    public void LoadScene(Scene sceneType)
    {
        Clear();
        NextScene = sceneType;
        SceneManager.LoadScene((int)sceneType);
    }

    public void Clear()
    {
        CurrentScene?.Clear();
    }
}
