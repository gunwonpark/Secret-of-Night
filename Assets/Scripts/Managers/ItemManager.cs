using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private PlayerGameData _playerData;
    private float _time = 60f;

    public void Start()
    {
        _playerData = GameManager.Instance.playerManager.playerData;
    }

    // 피 회복
    public void SmallHpPotion(float _amount)
    {
        _playerData.CurHP = Mathf.Min(_playerData.CurHP + _amount, _playerData.MaxHP);
    }

    public void BigHpPotion(float _amount)
    {
        _playerData.CurHP = Mathf.Min(_playerData.CurHP + _amount, _playerData.MaxHP);
    }

    // 마나 회복
    public void SmallMpPotion(float _amount)
    {
        _playerData.CurMP = Mathf.Min(_playerData.CurMP + _amount, _playerData.MaxMP);
    }

    public void BigMpPotion(float _amount)
    {
        _playerData.CurMP = Mathf.Min(_playerData.CurMP + _amount, _playerData.MaxMP);
    }

    // 스테미나 회복
    public void SmallSpPotion(float _amount)
    {
        _playerData.CurSP = Mathf.Min(_playerData.CurSP + _amount, _playerData.MaxSP);
    }

    public void BigSpPotion(float _amount)
    {
        _playerData.CurSP = Mathf.Min(_playerData.CurSP + _amount, _playerData.MaxSP);
    }

    //public void SpeedPotion(float _amount)
    //{
    //    _playerData.MoveSpeed += _amount;
    //    _time -= Time.deltaTime;
    //    _playerData.MoveSpeed -= _amount;
    //}
}
