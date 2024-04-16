using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlots : MonoBehaviour
{
    public Image itemImage;
    public Image itemCount_Image;
    public int itemCount;
    public TextMeshProUGUI itemCount_Text;
    public QuickInventoryItemSlot curSlot;

    public int index;

    public void ItemImage(float alpha)
    {
        Color color1 = itemCount_Image.color;
        color1.a = alpha;
        itemCount_Image.color = color1;
    }

    public void QuickSet(QuickInventoryItemSlot _slot)
    {
        curSlot = _slot;
        itemImage.sprite = Resources.Load<Sprite>(_slot.item.IconPath);
        itemImage.preserveAspect = true;
        itemCount_Text.text = _slot.count >= 1 ? _slot.count.ToString() : string.Empty;
        ItemImage(1);

    }

    public void ClearSlot()
    {
        curSlot = null;
        itemImage.sprite = Resources.Load<Sprite>("Images/Icons/cross");
        itemCount_Text.text = string.Empty;

        ItemImage(0);
    }

}
