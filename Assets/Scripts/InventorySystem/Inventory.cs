using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> InventorySlots;
    public int MaxSlots = 20;
    public ItemStack SelectedItemStack;
    public bool ResetInventory = false;
    public ItemBag ItemBag;

    public GameEvent OnInventoryChanged;
    //public GameEvent OnSelectedItemStackChanged;

    private void Awake()
    {
        CreateInventory();
    }
    
    private void OnEnable() 
    {
        ClearSelectedStack();
        InventoryResetCheck();
    }

    private void InventoryResetCheck()
    {
        Debug.Log("RESETING INVENTORY");
        if (ResetInventory)
        {
            ClearInventory();
        }
    }

    private void ClearInventory()
    {
        Debug.Log("CLEARING INVENTORY");
        foreach (InventorySlot slot in InventorySlots)
        {
            ClearStack(slot.Stack);
        }
    }

    private void ClearStack(ItemStack stack)
    {
        Debug.Log("CLEARING STACK");
        stack.Item = null;
        stack.Amount = 0;
    }

    private void CreateInventory()
    {
        Debug.Log("CREATING INVENTORY");
        InventorySlots = new List<InventorySlot>();
        if (InventorySlots.Count == 0)
        {
            for (int i = 0; i < MaxSlots; i++)
            {
                InventorySlots.Add(new InventorySlot());
                InventorySlots[i].ID = i+1;
            }
        }
        else
        {
            for (int i = 0; i < InventorySlots.Count; i++)
            {
                InventorySlots[i] = new InventorySlot();
                InventorySlots[i].ID = i+1;
            }
        }
    }

    public bool HasItem(InventoryItem item)
    {
        foreach (InventorySlot slot in InventorySlots)
        {
            if (slot.Stack.Item == item)
                return true;
        }
        return false;
    }

    public int GetSlotIDByItem(InventoryItem item)
    {
        foreach (InventorySlot slot in InventorySlots)
        {
            if (slot.Stack.Item == item)
                return slot.ID;
        }
        return 0;
    }

    public ItemStack GetStackByID(int slotID)
    {
        return InventorySlots[slotID-1].Stack;
    }

    public int GetAmount(InventoryItem item)
    {
        foreach (InventorySlot slot in InventorySlots)
        {
            if (slot.Stack.Item == item)
                return slot.Stack.Amount;
        }
        return 0;
    }

    public void AddItem(InventoryItem item, int amount)
    {
        Debug.Log("ADDING " + item);
        if (!IsFull())
        {
            Debug.Log("NOT FULL");
            if (!HasItem(item))
            {
                Debug.Log("DOESNT HAVE " + item);
                var slotID = GetEmptySlotID();
                InventorySlots[slotID-1].Stack.Item = item;
                InventorySlots[slotID-1].Stack.Amount = amount;
                InventorySlots[slotID-1].Stack.CalculateStackWeight();                
            }               
            else
            {
                InventorySlots[GetSlotIDByItem(item)-1].Stack.Amount += amount;
                InventorySlots[GetSlotIDByItem(item)-1].Stack.CalculateStackWeight();
            }
        }
        OnInventoryChanged.Raise();
    }

    public void RemoveItem(InventoryItem item, int amount)
    {
        if (HasItem(item))
        {
            var slotID = GetSlotIDByItem(item);
            if (InventorySlots[slotID-1].Stack.Amount > amount)
                InventorySlots[slotID-1].Stack.Amount -= amount;
            else if (InventorySlots[slotID-1].Stack.Amount == amount)
                ClearSlot(InventorySlots[slotID-1]);
            else if (InventorySlots[slotID-1].Stack.Amount < amount)
                return; //send message that inventory is full
        }
        OnInventoryChanged.Raise();
    }

    // public void UseItem(ConsumableItem item)
    // {
    //     item.Use(this);
    // }

    private int GetEmptySlotID()
    {
        foreach (InventorySlot slot in InventorySlots)
        {
            if (slot.Stack.Item == null)
            {
                return slot.ID;
            }
        }
        return 0;
    }

    private void ClearSlot(InventorySlot slot)
    {
        slot.Stack.Item = null;
        slot.Stack.Amount = 0;

    }

    public ItemStack FillStack(InventoryItem item, int amount)
    {
        ItemStack newStack = new ItemStack();
        newStack.Item = item;
        newStack.Amount = amount;
        return newStack;
    }

    public void ClearSelectedStack()
    {
        Debug.Log("CLEARING SELECTED STACK");
        SelectedItemStack.Item = null;
        SelectedItemStack.Amount = 0;
    }

    private bool IsFull()
    {
        if (GetEmptySlotID() == 0)
            return true;
        else
            return false;
    }

}

[Serializable]
public class InventorySlot : IComparable<InventorySlot>
{
    public int ID;
    public ItemStack Stack;

    public int CompareTo(InventorySlot slot)
    {
        if (slot.Stack.Item == null) return 1;
        if (slot.Stack.Item != null)
            return this.Stack.Item.Name.CompareTo(slot.Stack.Item.Name);
        else
            return 1;
    }
}

[Serializable]
public class ItemStack
{
    public InventoryItem Item;
    public int Amount;
    public float StackWeight;

    public void CalculateStackWeight()
    {
        StackWeight = Item.Weight * (float)Amount;
    }
}

public interface IHasInventory
{
    //nothing
}