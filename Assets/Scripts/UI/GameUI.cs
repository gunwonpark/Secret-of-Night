using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UIBase
{
    //캐싱용
    private PlayerGameData playerData;

    [Header("Status")]
    [SerializeField] private Image _hpImage;
    [SerializeField] private Image _mpImage;

    [Header("Stamina")]
    [SerializeField] private Image _staminaImage;

    private void Start()
    {
        playerData = GameManager.Instance.playerManager.playerData;
        playerData.OnHPChange += UpdateHP;
        playerData.OnMPChange += UpdateMP;
        playerData.OnSPChange += UpdateSP;
    }

    private void UpdateHP()
    {
        _hpImage.fillAmount = playerData.CurHP / playerData.MaxHP;
    }
    private void UpdateMP()
    {
        _mpImage.fillAmount = playerData.CurMP / playerData.MaxMP;
    }
    private void UpdateSP()
    {
        _staminaImage.fillAmount = playerData.CurSP / playerData.MaxSP;
    }
    #region BuffSystem
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
    #endregion

    private void OnDestroy()
    {
        playerData.OnHPChange -= UpdateHP;
        playerData.OnMPChange -= UpdateMP;
        playerData.OnSPChange -= UpdateSP;
    }
}
