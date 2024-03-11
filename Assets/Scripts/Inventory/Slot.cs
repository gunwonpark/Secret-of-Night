using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemData item;
    public Image itemImage;
    public int itemCount;

    [SerializeField] private TextMeshProUGUI _itemCountText;

    //아이템 이미지 투명도 조절 (기본 0)
    private void ItemImage(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    //아이템 슬롯에 추가
    public void AddItem(ItemData _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.icon;

        //장착 아이템이 아니면 카운트
        if (item.type != ItemType.Equipment)
        {
            _itemCountText.text = itemCount.ToString();
        }
        else
        {
            _itemCountText.text = "0";
        }

        ItemImage(1); //아이템 투명도 1
    }

    // 아이템 수량 업데이트
    public void SlotCount(int _count)
    {
        itemCount += _count;
        _itemCountText.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    //아이템이 비워질 때 초기화
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        ItemImage(0);

        _itemCountText.text = "0";
    }
}
