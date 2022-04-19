using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite ItemIcon;
    public typ ItemType;
    public int Damage;
    [Range(1, 100)]public int maxStackSize = 100;
}
public enum typ
{
    RangeWepon,
    MeleeWeapon,
    Tool,
    Item
}