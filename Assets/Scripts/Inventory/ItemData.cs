using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string Name;
    public string Type;
    public float Price;
    public float Damage;
    public float Critical;
    public int Money;
    public string ItemName;
    public string Description;
}

//json을 불러오기 위해
public class ItemInstance
{
    public Item item;
}


[System.Serializable]
public class ItemData
{
    public List<Item> items;
    public Dictionary<string, Item> itemDic = new Dictionary<string, Item>();

    public void Initialize()
    {
        foreach (Item item in items)
        {
            itemDic.Add(item.Name, item);
        }
    }

    public Item GetItemByKey(string name)
    {
        if (itemDic.ContainsKey(name)) // 키가 있는지 확인
            return itemDic[name];

        return null;
    }
}
