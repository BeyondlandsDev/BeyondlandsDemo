using UnityEngine;

public class PickupableItem : Interactable
{
    public ItemStack Stack;

    public void OnEnable()
    {
        NameText = Stack.Item.Name;
        ActionText = "Pick up";
    }

    public override void Interact(PlayerReferences player)
    {
        player.Inventory.AddItem(this.Stack.Item, this.Stack.Amount);

        //add item to inventory
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
        //remove item gameobject
    }
}
