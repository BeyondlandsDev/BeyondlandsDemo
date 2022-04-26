using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemOptionButton : MonoBehaviour
{
    public TextMeshProUGUI Text;
    //public InventorySlot Slot;
    public OptionAction Action;
    public UI_InventoryDisplay UI;

    private void Awake()
    {
        UI = GetComponentInParent<UI_InventoryDisplay>();
    }

    public void ButtonClick()
    {
        Action.Action(UI);
    }
}
