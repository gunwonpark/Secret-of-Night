using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : MonoBehaviour
{
    public BaseScene CurrentScene;
    public Scene PrevScene;
    //비동기 씬전환 목적
    public Scene NextScene;
    public void LoadSceneAsync(Scene sceneType)
    {
        if (CurrentScene != null)
        {
            PrevScene = CurrentScene.SceneType;
            Clear();
        }
        NextScene = sceneType;
        SceneManager.LoadScene((int)Scene.Loading);

    }
    public void LoadScene(Scene sceneType)
    {
        if (CurrentScene != null)
        {
            PrevScene = CurrentScene.SceneType;
            Clear();
        }
        NextScene = sceneType;
        SceneManager.LoadScene((int)sceneType);
    }

    public void Clear()
    {
        CurrentScene?.Clear();
    }
}
