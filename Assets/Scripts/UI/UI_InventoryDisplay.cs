using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InventoryDisplay : MonoBehaviour
{
    public Inventory CurrentInventory;

    [Header("Inventory Slots")]
    [SerializeField] private GridLayoutGroup inventorySlotGroup;
    [SerializeField] private GameObject slotButtonPrefab;
    [SerializeField] private List<GameObject> slotButtons;
    [SerializeField] private Sprite defaultIcon;

    [Header("Item Inspect")]
    public ItemInspectDisplay ItemInspectDisplay = new ItemInspectDisplay();
    [SerializeField] private ItemOptionButton optionButtonPrefab;
    [SerializeField] private List<ItemOptionButton> optionButtons;

    private void Awake()
    {
        slotButtons = new List<GameObject>();
        CreateInventoryDisplay();
        ClearInspectDisplay(); 
    }

    private void OnEnable()
    {
        UpdateDisplay();
        ClearInspectDisplay();
    }

    private void FixedUpdate()
    {
        UpdateDisplay();
        //UpdateInspectDisplay(CurrentInventory.SelectedItemStack);
    }

    private void OnDisable()
    {
        CurrentInventory.ClearSelectedStack();
    }

    private void CreateInventoryDisplay()
    {
        for (int i = 0; i < CurrentInventory.MaxSlots; i++)
        {
            slotButtons.Add(
                Instantiate(slotButtonPrefab, inventorySlotGroup.transform));
        }
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < CurrentInventory.InventorySlots.Count; i++)
        {
            var button = slotButtons[i].GetComponent<InventorySlotButton>();
            button.SlotID = CurrentInventory.InventorySlots[i].ID;

            if (CurrentInventory.InventorySlots[i].Stack.Item != null)
            {
                button.Icon.sprite = CurrentInventory.InventorySlots[i].Stack.Item.Icon;
                button.NameText.text = CurrentInventory.InventorySlots[i].Stack.Item.Name;
                button.AmountText.text = "x"+CurrentInventory.InventorySlots[i].Stack.Amount.ToString();
                button.WeightText.text = CurrentInventory.InventorySlots[i].Stack.StackWeight.ToString();
            }
            else
            {
                button.Icon.sprite = defaultIcon;
                button.NameText.text = "";
                button.AmountText.text = "";
                button.WeightText.text = "";
            }
        }
    }

    public void FillInspectDisplay(ItemStack stack)
    {
        ClearInspectDisplay();
        //Debug.Log("SLOT IS NOT NULL");
        //Debug.Log("THIS SLOT HAS " + stack.Item);
        
        InventoryItem item = stack.Item;

        ItemInspectDisplay.Icon.sprite = item.Icon;
        ItemInspectDisplay.NameText.text = item.Name;
        ItemInspectDisplay.AmountText.text = "x"+stack.Amount.ToString();
        ItemInspectDisplay.DescriptionText.text = item.Description;
        if (optionButtons.Count == 0)
        {
            ClearOptionButtons();
            GenerateOptionButtons(stack);
            FillOptionButtons(stack);
        } 
    }

    public void GenerateOptionButtons(ItemStack stack)
    {
        for (int i = 0; i < stack.Item.Type.Options.Count; i++)
        {
            optionButtons.Add(Instantiate(optionButtonPrefab, ItemInspectDisplay.OptionGrid.transform));
        }
    }

    public void FillOptionButtons(ItemStack stack)
    {
        for (int i = 0; i < stack.Item.Type.Options.Count; i++)
        {
            optionButtons[i].Text.text = stack.Item.Type.Options[i].Name;
            optionButtons[i].Action = stack.Item.Type.Options[i].Action;
        }
    }

    public void ClearOptionButtons()
    {
        //Debug.Log("CLEARING OPTION BUTTONS");
        optionButtons.Clear();
    }

    public void ClearInspectDisplay()
    {
        //Debug.Log("SLOT IS NULL");
        ItemInspectDisplay.Icon.sprite = defaultIcon;
        ItemInspectDisplay.NameText.text = "";
        ItemInspectDisplay.AmountText.text = "";
        ItemInspectDisplay.DescriptionText.text = "";
        //Debug.Log("CLEARING INSPECT");
        for (int i = 0; i < optionButtons.Count; i++)
        {
            DestroyImmediate(optionButtons[i].gameObject);
        }
        ClearOptionButtons();
    }

    public void UpdateInspectDisplay(ItemStack stack)
    {
        if (stack.Item != null)
        {
            FillInspectDisplay(stack);
        }
        else
        {
            ClearInspectDisplay();
        }
    }

}
