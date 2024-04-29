public class LoadingScene : BaseScene
{
    public override void Clear()
    {

    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameManager.Instance.playerManager.playerData.SaveData();
    }
}