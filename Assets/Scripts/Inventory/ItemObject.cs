using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public int Id; // 아이템의 이름을 저장할 변수 (키)
    public Item item;

    private void Start()
    {
        item = GameManager.Instance.dataManager.itemDataBase.GetData(Id);
    }
}
