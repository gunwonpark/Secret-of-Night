using System.Collections.Generic;
using UnityEngine;

public class GameUI : UIBase
{
    [Header("Buff System")]
    public RectTransform prefab;
    public RectTransform parent;

    private List<RectTransform> _slots = new List<RectTransform>();

    private const int slotSize = 70;
    private const int slotSpacing = 10;
    private const int slotPerRow = 9;
    private const int rowSpacing = 10;

    public void ShowBuff()
    {
        RectTransform newSlot = Instantiate(prefab, parent);
        _slots.Add(newSlot);
        UpdateLayout();
    }
    private void UpdateLayout()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i] == null)
            {
                _slots.RemoveAt(i);
            }
        }
        for (int i = 0; i < _slots.Count; i++)
        {
            int row = i / slotPerRow;
            int column = i % slotPerRow;
            float x = column * (slotSize + slotSpacing);
            float y = row * (slotSize + rowSpacing);
            _slots[i].anchoredPosition = new Vector2(x, y);
            _slots[i].sizeDelta = new Vector2(slotSize, slotSize);
        }
    }
}
