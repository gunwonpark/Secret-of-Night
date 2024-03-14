using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public Image itemImage;
    public int itemCount;

    public int index;

    [SerializeField] private TextMeshProUGUI _itemCountText;

    public void ItemImage(float alpha)
    {
        Color color = itemImage.color;
        color.a = alpha;
        itemImage.color = color;
    }

    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = Resources.Load<Sprite>(_item.IconPath);

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
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        ItemImage(0);

        _itemCountText.text = "";
    }

    // 슬롯 클릭시 아이템 정보 보이게
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item != null)
            {
                Inventory.instance.UpdateSelectedItemInfo(item);
            }
        }
    }
}
