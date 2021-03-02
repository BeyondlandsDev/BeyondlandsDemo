using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_TargetInfo : MonoBehaviour
{
    public InteractableVariable Target;

    [SerializeField]
    private TMP_Text text;

    private void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (Target.CurrentValue != null)
            //text.text = $"{Target.CurrentValue.Action.ActionText} {Target.CurrentValue.Item.Name}";
            text.text = $"{Target.CurrentValue.Action.ActionText} {Target.CurrentValue.name}";
        else
            text.text = null;
    }
}
