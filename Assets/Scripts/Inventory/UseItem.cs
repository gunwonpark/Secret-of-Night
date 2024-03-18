using UnityEngine;

public class UseItem : MonoBehaviour
{
    public PlayerGameData PlayerData { get; set; }

    public void Start()
    {

        PlayerData = GameManager.Instance.playerManager.playerData;

        Debug.Log(PlayerData.CurHP);
    }

    // 피 회복
    public void SmallHpPotion(float amount)
    {
        PlayerData.CurHP = Mathf.Min(PlayerData.CurHP + amount, PlayerData.MaxHP);
    }

    public void BigHpPotion(float amount)
    {
        PlayerData.CurHP = Mathf.Min(PlayerData.CurHP + amount, PlayerData.MaxHP);
    }

    // 마나 회복
    public void SmallMpPotion(float amount)
    {
        PlayerData.CurMP = Mathf.Min(PlayerData.CurMP + amount, PlayerData.MaxMP);
    }

    public void BigMpPotion(float amount)
    {
        PlayerData.CurMP = Mathf.Min(PlayerData.CurMP + amount, PlayerData.MaxMP);
    }

    // 스테미나 회복
    public void SmallSpPotion(float amount)
    {
        PlayerData.CurMP = Mathf.Min(PlayerData.CurSP + amount, PlayerData.MaxSP);
    }

    public void BigSpPotion(float amount)
    {
        PlayerData.CurMP = Mathf.Min(PlayerData.CurSP + amount, PlayerData.MaxSP);
    }
}
