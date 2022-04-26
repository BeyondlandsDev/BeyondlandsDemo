using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBag : Interactable
{
    [SerializeField]
    private InventoryItem item;
    public InventoryItem Item { get => item; set => item = value; }

    public void SetItem(InventoryItem item)
    {
        Item = item;
        NameText = item.Name;
        ActionText = "Pick Up";
    }

    public override void Interact(PlayerReferences player)
    {
        player.Inventory.AddItem(this.Item, 1);
        //add item to inventory
        this.gameObject.SetActive(false);
        //remove item gameobject
    }
}
