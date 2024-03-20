using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Image itemImage;
    public int itemCount;
    public TextMeshProUGUI _itemCountText;
    private ItemSlot curSlot; //현재 슬롯 
    private Outline _outline; //장착 아이템 테두리

    public int index;
    public bool equipped;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        _outline.enabled = equipped;
    }

    public void ItemImage(float alpha)
    {
        Color color = itemImage.color;
        color.a = alpha;
        itemImage.color = color;
    }

    public void Set(ItemSlot _slot)
    {
        curSlot = _slot;
        itemImage.sprite = Resources.Load<Sprite>(_slot.item.IconPath);
        itemImage.preserveAspect = true; //들어가는 이미지 비율을 부모에 맞게 지정
        _itemCountText.text = _slot.count > 1 ? _slot.count.ToString() : string.Empty;

        if (_outline != null)
        {
            _outline.enabled = equipped;
        }

        ItemImage(1); //아이템 표시하기 위해 투명도 1
    }


    public void ClearSlot()
    {
        curSlot = null;
        itemImage.sprite = null;
        _itemCountText.text = string.Empty;

        ItemImage(0);
    }

    // 슬롯 클릭시 아이템 정보 보이게
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Inventory.instance.SelectItem(index);
        }
    }
}
