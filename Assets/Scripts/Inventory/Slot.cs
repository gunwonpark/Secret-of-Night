using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public Image itemImage;
    public int itemCount;

    [SerializeField] private TextMeshProUGUI _itemCountText;

    private void ItemImage(float alpha)
    {
        Color color = itemImage.color;
        color.a = alpha;
        itemImage.color = color;
    }

    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = Resources.Load<Sprite>("");

        if (_item.Type != "Equipment")
        {
            _itemCountText.text = itemCount.ToString();
        }
        else
        {
            _itemCountText.text = "0";
        }

        ItemImage(1);
    }

    public void SlotCount(int _count)
    {
        itemCount += _count;
        _itemCountText.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        itemCount = 0;
        itemImage.sprite = null;
        ItemImage(0);

        _itemCountText.text = "";
    }
}
