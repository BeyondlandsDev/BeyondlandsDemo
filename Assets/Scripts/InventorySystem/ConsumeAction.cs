using UnityEngine;

[CreateAssetMenu(fileName = "Consume Action", menuName = "Inventory Items/Actions/Consume Action")]
public class ConsumeAction : OptionAction
{
    public override void Action(UI_InventoryDisplay ui)
    {
        var stack = ui.CurrentInventory.SelectedItemStack;
        var item = stack.Item;

        if (item != null)
        {
            foreach (StatusEffect effect in item.StatEffects)
            {
                effect.Apply();
            }
            ui.CurrentInventory.RemoveItem(item, 1);
        }
         ui.UpdateInspectDisplay(stack);
    }
}
