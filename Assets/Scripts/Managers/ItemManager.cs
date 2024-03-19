using System.Collections;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private PlayerGameData _playerData;

    public bool speedItemInUse = false;

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

    // 이동속도 증가
    public void SpeedPotion(float _amount)
    {
        if (!speedItemInUse) //아이템 사용 중이 아닌 경우에만 아이템 사용
        {
            _playerData.MoveSpeed += _amount;
            StartCoroutine(SpeedCoroutine(_amount));
            speedItemInUse = true;
        }
    }

    IEnumerator SpeedCoroutine(float _amount)
    {
        Debug.Log("스피드 업 : " + _playerData.MoveSpeed);
        yield return new WaitForSeconds(5f); //TODO 60초로 수정
        _playerData.MoveSpeed -= _amount;
        Debug.Log("종료 : " + _playerData.MoveSpeed);
        speedItemInUse = false;
    }
}
