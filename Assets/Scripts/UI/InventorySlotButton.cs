using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotButton : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI AmountText;
    public TextMeshProUGUI WeightText;
    public int SlotID;
    public UI_InventoryDisplay UI;

    private void Awake() 
    {
        UI = GetComponentInParent<UI_InventoryDisplay>();
    }

    public void ButtonClick()
    {
        UI.CurrentInventory.SelectedItemStack = UI.CurrentInventory.GetStackByID(SlotID);
        UI.UpdateInspectDisplay(UI.CurrentInventory.SelectedItemStack);
    }
}