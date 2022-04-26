using UnityEngine;

[CreateAssetMenu(fileName = "New Item Inspect Option", menuName = "Inventory Items/Item Inspect Option")]
public class InspectOption : ScriptableObject
{
    public string Name;
    public OptionAction Action;
}