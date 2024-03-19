using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int ItemID;
    public string Name;
    public string Type;
    public float Price;
    public float Damage;
    public float Critical;
    public int Money;
    public string ItemName;
    public string Description;
    public string IconPath;
    public int MaxAmount;
    public string PrefabPath;
    public GameObject Prefab;
}

//json을 불러오기 위해
public class ItemInstance
{
    public Item item;
}


[System.Serializable]
public class ItemData : DataBase<int, Item>
{
    public List<Item> items;

    protected override void LoadData()
    {
        foreach (Item item in items)
        {
            data.Add(item.ItemID, item);
            item.Prefab = Resources.Load<GameObject>(item.PrefabPath);
        }
    }
}
