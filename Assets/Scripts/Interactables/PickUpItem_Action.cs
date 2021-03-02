using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ACTION_PickUpItem", menuName = "Interactable Actions/Pick Up Item Action")]
public class PickUpItem_Action : InteractableAction
{
    //public Inventory Inventory;

    public override void Action(Interactable interactable)
    {
        //Inventory.AddItem(interactable.Item, 1);
        interactable.gameObject.SetActive(false);
        Debug.Log("PICK UP");
    }
}
