using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionAction : ScriptableObject
{
    public string Name;
    
    public virtual void Action(UI_InventoryDisplay ui)
    {
        //nothing to see here
        //ui.UpdateInspectDisplay(slot);
    }
}
