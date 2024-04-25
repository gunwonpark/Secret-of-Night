using UnityEngine;

public class GameStartScene : BaseScene
{
    [SerializeField] private AudioClip _bgm;

    public override void Initizlize()
    {
        base.Initizlize();
        SceneType = Scene.GameStart;

        GameManager.Instance.soundManager.PlayBGM(_bgm);

    }
    public override void Clear()
    {

    }
}
