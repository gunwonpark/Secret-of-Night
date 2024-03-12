using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    public ItemData itemData;

    private void Awake()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Json/Items_Data");
        if (jsonFile != null)
        {
            string json = jsonFile.text;

            itemData = JsonUtility.FromJson<ItemData>(json);
            itemData.Initialize();
        }

        //string itemKey = "SmallHPPotion";
        //Item foundItem = itemData.GetItemByKey(itemKey);
        //if (foundItem != null)
        //{
        //    Debug.Log(foundItem.ItemName);
        //    Debug.Log(foundItem.Description);
        //}
        //else
        //{
        //    Debug.Log("아이템 못찾음");
        //}
    }
}
