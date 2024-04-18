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
    public abstract void Clear();
}
