using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Scene SceneType { get; protected set; } = Scene.None;
    void Start()
    {
        Initizlize();
    }

    public virtual void Initizlize()
    {
        GameManager.Instance.sceneManager.CurrentScene = this;
    }
    private void OnDestroy()
    {
        GameManager.Instance.inputManager.Initialize();
        GameManager.Instance.playerManager.playerData.SaveData();
    }
    public abstract void Clear();
}
