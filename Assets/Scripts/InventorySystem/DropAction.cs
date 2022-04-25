using UnityEngine;

[CreateAssetMenu(fileName = "Drop Action", menuName = "Inventory Items/Actions/Drop Action")]
public class DropAction : OptionAction
{
    private ItemBag bag;
    private InventoryItem item;

    public override void Action(UI_InventoryDisplay ui)
    {
        Debug.Log("DROPPING ITEM");

        var stack = ui.CurrentInventory.SelectedItemStack;
        var player = FindObjectOfType<PlayerController>().transform;

        if (stack.Item != null)
        {
            item = stack.Item;
            bag = Instantiate(ui.CurrentInventory.ItemBag, player.position+(player.forward*2), player.rotation);
            bag.SetItem(item);
            ui.CurrentInventory.RemoveItem(item, 1);
        }

        ui.UpdateInspectDisplay(stack);
    }
}
