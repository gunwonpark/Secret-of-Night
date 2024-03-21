using UnityEngine;

public class EquipController : MonoBehaviour
{
    public GameObject curEquip;
    public Transform equipParent;

    private PlayerGameData _playerData;
    private float _defultDamage;

    private void Start()
    {
        _playerData = GameManager.Instance.playerManager.playerData;
        EquipDefaultWeapon();
    }

    //기본 무기의 정보를 가져와서 장착
    public void EquipDefaultWeapon()
    {
        Item defaultWeapon = GameManager.Instance.dataManager.itemDataBase.GetData(8);

        PlayerNewEquip(defaultWeapon);
        EquipWeaponPower(defaultWeapon.ItemID, defaultWeapon.Damage);

    }

    // 캐릭터 손에 무기 장착
    public void PlayerNewEquip(Item _item)
    {
        PlayerUnEquip();
        curEquip = Instantiate(_item.Prefab, equipParent);
        curEquip.GetComponent<Collider>().enabled = false; // 손에 장착한 무기는 인식 x

    }
    public void PlayerUnEquip()
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;

        }
    }

    // 무기 장착시 공격력 변화
    public void EquipWeaponPower(int _id, float _damage)
    {
        _defultDamage = _playerData.Damage;
        _playerData.Damage = _defultDamage + _damage;
    }

    public void UnEquipWeaponPower()
    {
        _playerData.Damage = _defultDamage;
    }
}
