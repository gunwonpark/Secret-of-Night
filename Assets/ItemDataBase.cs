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
    public int UnlockLevel;
    public GameObject Prefab;
}


[System.Serializable]
public class ItemDataBase : DataBase<int, Item>
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

    //원하는 아이템 리스트만 불러올 수 있음
    public List<Item> GetAllItems(int startID, int endID)
    {
        List<Item> list = new List<Item>();
        foreach (Item item in items)
        {
            if (item.ItemID >= startID && item.ItemID <= endID)
            {
                list.Add(item);
            }
        }
        return list;
    }

    public List<Item> GetItems(int ID)
    {
        List<Item> list = new List<Item>();
        foreach (Item item in items)
        {
            if (item.ItemID == ID)
            {
                list.Add(item);
            }
        }
        return list;
    }
}

