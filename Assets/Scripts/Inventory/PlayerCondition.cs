using System.Collections;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    private PlayerGameData _playerData;

    public bool speedItemInUse = false;

    public void Start()
    {
        _playerData = GameManager.Instance.playerManager.playerData;
    }

    // 체력 아이템
    public void SmallHpPotion(float _amount)
    {
        _playerData.CurHP = Mathf.Min(_playerData.CurHP + _amount, _playerData.MaxHP);
        GameManager.Instance.playerManager.playerData.HPChange(_amount);
    }

    public void BigHpPotion(float _amount)
    {
        _playerData.CurHP = Mathf.Min(_playerData.CurHP + _amount, _playerData.MaxHP);
        GameManager.Instance.playerManager.playerData.HPChange(_amount);
    }

    // 마나 아이템
    public void SmallMpPotion(float _amount)
    {
        _playerData.CurMP = Mathf.Min(_playerData.CurMP + _amount, _playerData.MaxMP);
        GameManager.Instance.playerManager.playerData.MPChange(_amount);
    }

    public void BigMpPotion(float _amount)
    {
        _playerData.CurMP = Mathf.Min(_playerData.CurMP + _amount, _playerData.MaxMP);
        GameManager.Instance.playerManager.playerData.MPChange(_amount);
    }

    // 스테미나 아이템
    public void SmallSpPotion(float _amount)
    {
        _playerData.CurSP = Mathf.Min(_playerData.CurSP + _amount, _playerData.MaxSP);
        GameManager.Instance.playerManager.playerData.SPChange(_amount);
    }

    public void BigSpPotion(float _amount)
    {
        _playerData.CurSP = Mathf.Min(_playerData.CurSP + _amount, _playerData.MaxSP);
        GameManager.Instance.playerManager.playerData.SPChange(_amount);
    }

    // 이동속도 아이템
    public void SpeedPotion(float _amount)
    {
        if (!speedItemInUse)
        {
            _playerData.MoveSpeed += _amount;
            StartCoroutine(SpeedCoroutine(_amount));
            speedItemInUse = true;
        }
    }
    // 코루틴
    IEnumerator SpeedCoroutine(float _amount)
    {
        Debug.Log("스피드 업 : " + _playerData.MoveSpeed);
        yield return new WaitForSeconds(60f);
        _playerData.MoveSpeed -= _amount;
        Debug.Log("스피드 다운 : " + _playerData.MoveSpeed);
        speedItemInUse = false;
    }
}
