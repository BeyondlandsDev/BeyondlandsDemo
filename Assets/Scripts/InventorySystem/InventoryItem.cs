using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum ItemType
// {
//     DEFAULT,
//     Consumable,
//     Equipment
// }

[CreateAssetMenu(fileName = "New Default Inventory Item", menuName = "Inventory Items/Default Item")]
public class InventoryItem : ScriptableObject
{
    public int ID;
    public Sprite Icon;
    public string Name = "Default Item";
    [Multiline]
    public string Description;
    public float Weight;
    public ItemType Type;

    public List<StatusEffect> StatEffects;


    //public List<InspectOption> AvailableOptions;
    //public ItemUse Use;
}
