using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Image itemImage;
    public int itemCount;
    public TextMeshProUGUI _itemCountText;
    public ItemSlot curSlot; //현재 슬롯 
    public Outline _outline; //장착 아이템 테두리

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

    float clickTime = 0;

    // 슬롯 클릭시 아이템 정보 보이게
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Inventory.instance.SelectItem(index);
        }

        // 더블클릭 간주
        if ((Time.time - clickTime) < 0.3f)
        {
            clickTime = -1;
            Debug.Log("더블클릭");

            // 퀵슬롯에 저장하는 코드 추가
            if (curSlot != null && (Inventory.instance._selectedItem.item.Type == "using"))
            {
                if (Inventory.instance._quickSlotInventory.slots[Inventory.instance._quickSlotInventory._selectedItemIndex].item == null)
                {
                    Inventory.instance._quickSlotInventory.AddItem(curSlot.item, curSlot.count);
                    Inventory.instance.RemoveItemByID(curSlot.item.ItemID, curSlot.count);
                }
                else if (Inventory.instance._quickSlotInventory.slots[Inventory.instance._quickSlotInventory._selectedItemIndex].item.ItemID == curSlot.item.ItemID)
                {
                    int totalCount = curSlot.count + Inventory.instance._selectedItem.count;
                    Inventory.instance._quickSlotInventory.AddItem(curSlot.item, totalCount);
                    Inventory.instance.RemoveItemByID(curSlot.item.ItemID, curSlot.count);
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            clickTime = Time.time;
        }
    }
}
