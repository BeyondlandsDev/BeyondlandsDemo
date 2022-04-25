using UnityEngine;
using System;

[Serializable]
public class UIReferences
{
    public CurrentGameState CurrentState;

    // [Header("Menu Background")]
    // public GameObject Background;

    [Header("Inventory UI")]
    public GameObject InventoryUI;

    [Header("Player References")]
    public Inventory PlayerInventory;
    public InteractableVariable PlayerTarget;
}
