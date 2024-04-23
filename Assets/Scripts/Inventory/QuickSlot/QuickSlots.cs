using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuickSlots : MonoBehaviour, IPointerClickHandler
{
    public Image itemImage;
    public Image itemCount_Image;
    public int itemCount;
    public TextMeshProUGUI itemCount_Text;
    public QuickInventoryItemSlot curSlot;

    private QuickSlotInventory _quickSlotInventory;

    public int index;

    private void Start()
    {
        _quickSlotInventory = GetComponentInParent<QuickSlotInventory>();
    }
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

    float clickTime = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        _quickSlotInventory.SelectItem(index);
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (curSlot != null)
            {
                Inventory.instance.RemoveItemByID(curSlot.item.ItemID, 1);

                _quickSlotInventory.OnUseButton();

                Inventory.instance.ClearSeletecItemWindow();
                //Inventory.instance.InventoryTrim();
            }
            else
            {
                return;
            }
        }

        //// 더블클릭 간주
        //if ((Time.time - clickTime) < 0.3f)
        //{
        //    clickTime = -1;
        //    Debug.Log("더블클릭");

        //    if (curSlot != null)
        //    {
        //        Inventory.instance.RemoveItemByID(curSlot.item.ItemID, 1);
        //        _quickSlotInventory.RemoveItemByID(curSlot.item.ItemID, 1);

        //        Inventory.instance.ClearSeletecItemWindow();
        //        Inventory.instance.InventoryTrim();

        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        //else
        //{
        //    clickTime = Time.time;
        //}
    }
}
