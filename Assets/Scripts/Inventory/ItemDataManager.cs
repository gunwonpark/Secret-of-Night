using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    public static ItemDataManager Instance;
    public ItemData itemData;

    private void Awake()
    {
        Instance = this;

        TextAsset jsonFile = Resources.Load<TextAsset>("Json/Items_Data");
        if (jsonFile != null)
        {
            string json = jsonFile.text;

            itemData = JsonUtility.FromJson<ItemData>(json);
            itemData.Initialize();
        }
    }
}
