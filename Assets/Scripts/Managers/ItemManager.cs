using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private PlayerGameData _playerData;

    public void Start()
    {
        _playerData = GameManager.Instance.playerManager.playerData;
    }

    // 피 회복
    public void SmallHpPotion(float amount)
    {
        _playerData.CurHP = Mathf.Min(_playerData.CurHP + amount, _playerData.MaxHP);
    }

    public void BigHpPotion(float amount)
    {
        _playerData.CurHP = Mathf.Min(_playerData.CurHP + amount, _playerData.MaxHP);
    }

    // 마나 회복
    public void SmallMpPotion(float amount)
    {
        _playerData.CurMP = Mathf.Min(_playerData.CurMP + amount, _playerData.MaxMP);
    }

    public void BigMpPotion(float amount)
    {
        _playerData.CurMP = Mathf.Min(_playerData.CurMP + amount, _playerData.MaxMP);
    }

    // 스테미나 회복
    public void SmallSpPotion(float amount)
    {
        _playerData.CurSP = Mathf.Min(_playerData.CurSP + amount, _playerData.MaxSP);
    }

    public void BigSpPotion(float amount)
    {
        _playerData.CurSP = Mathf.Min(_playerData.CurSP + amount, _playerData.MaxSP);
    }
}
