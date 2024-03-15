using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public GameObject curEquip;
    public Transform equipParent;

    public static EquipManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void NewEquip(Item item)
    {
        curEquip = Instantiate(item.Prefab, equipParent);
        curEquip.GetComponent<Collider>().enabled = false;
    }
    public void UnEquip()
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip.GetComponent<Collider>().enabled = true;
            curEquip = null;

        }

    }
}
