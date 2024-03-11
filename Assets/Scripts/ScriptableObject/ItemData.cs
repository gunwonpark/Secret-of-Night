using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    //무기,장비 / 소모품 / 재료
    Equipment,
    Consumable,
    Ingredient,
}

public enum consumable
{
    Hunger,
    Health,
}

[CreateAssetMenu(fileName ="Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string name;
    public string description;
    public Sprite icon;
    public ItemType type;
    public GameObject dripPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;
}
