using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemInstance _itemInstance;
    public Image itemImage;
    public int itemCount;

    [SerializeField] private TextMeshProUGUI _itemCountText;

    private void ItemImage(float alpha)
    {
        Color color = itemImage.color;
        color.a = alpha;
        itemImage.color = color;
    }

    public void AddItem(ItemInstance ItemInstance, int count = 1)
    {
        _itemInstance = ItemInstance;
        itemCount = count;
        itemImage.sprite = Resources.Load<Sprite>("");

        if (_itemInstance.item.Type != "Equipment")
        {
            _itemCountText.text = itemCount.ToString();
        }
        else
        {
            _itemCountText.text = "0";
        }

        ItemImage(1);
    }

    public void SlotCount(int count)
    {
        itemCount += count;
        _itemCountText.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        _itemInstance = null;
        itemCount = 0;
        itemImage.sprite = null;
        ItemImage(0);

        _itemCountText.text = "";
    }
}
