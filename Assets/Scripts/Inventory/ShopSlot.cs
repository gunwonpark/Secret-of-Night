using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    public Item item; // 아이템 정보
    public Image itemImage; // 아이템 이미지 컴포넌트

    public int shopIndex;

    // 아이템 이미지 투명도 조절
    public void ItemImage(float alpha)
    {
        Color color = itemImage.color;
        color.a = alpha;
        itemImage.color = color;
    }

    // 상점 슬롯에 아이템 설정
    public void ShopSetItem(Item _item)
    {
        item = _item;
        if (item != null)
        {
            // 아이템의 아이콘을 이미지로 설정
            itemImage.sprite = Resources.Load<Sprite>(item.IconPath);
            itemImage.preserveAspect = true;
        }
        ItemImage(1); // 아이템 표시를 위해 투명도를 1로 설정
    }

    public void ShopClearSlot()
    {
        item = null;
        itemImage.sprite = null;

        ItemImage(0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Shop.instance.SelectItem(shopIndex);
        }
    }
}
