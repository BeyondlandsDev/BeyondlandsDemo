using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_TargetInfo : MonoBehaviour
{
    public InteractableVariable Target;

    [SerializeField]
    private TMP_Text targetName;

    [SerializeField]
    private TMP_Text actionText;

    private void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (Target.CurrentValue != null)
        {
            targetName.text = $"{Target.CurrentValue.NameText}";
            actionText.text = $"[e] {Target.CurrentValue.ActionText}";
        }
        else
        {
            targetName.text = null;
            actionText.text = null;
        }
    }
}
