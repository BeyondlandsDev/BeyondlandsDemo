using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Type", menuName = "Inventory Items/Item Type")]
public class ItemType : ScriptableObject
{
    public string Name;
    public List<InspectOption> Options;
}
