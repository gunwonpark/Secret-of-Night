using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class QuickInventorySlots : MonoBehaviour, IPointerClickHandler
{
    public Image itemImage;
    public Image itemCount_Image;
    public int itemCount;
    public TextMeshProUGUI itemCount_Text;
    public QuickInventorySettingItemSlot curSlot;

    private QuickSlotInventory _quickSlotInventory;
    private QuickSlotInventorySetting _quickSlotIventorySetting;

    public int index;

    void Start()
    {
        _quickSlotInventory = FindObjectOfType<QuickSlotInventory>();
        _quickSlotIventorySetting = FindObjectOfType<QuickSlotInventorySetting>();
    }

    public void ItemImage(float alpha)
    {
        Color color = itemImage.color;
        Color color1 = itemCount_Image.color;
        color.a = alpha;
        color1.a = alpha;
        itemImage.color = color;
        itemCount_Image.color = color1;
    }

    public void QuickSet(QuickInventorySettingItemSlot _slot)
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
        itemImage.sprite = null;
        itemCount_Text.text = string.Empty;

        ItemImage(0);
    }


    float clickTime = 0;

    // 더블 클릭
    public void OnPointerClick(PointerEventData eventData)
    {
        _quickSlotIventorySetting.SelectItem(index);

        // 더블클릭 간주
        if ((Time.time - clickTime) < 0.3f)
        {
            clickTime = -1;
            Debug.Log("더블클릭");
            // 퀵슬롯에 저장하는 코드 추가

            if (curSlot.item != null && _quickSlotInventory.slots[_quickSlotInventory._selectedItemIndex].item == null)
            {
                _quickSlotInventory.AddItem(curSlot.item, curSlot.count);
                _quickSlotIventorySetting.RemoveSelectedItem();
            }
        }
        else
        {
            clickTime = Time.time;
        }
    }

}
