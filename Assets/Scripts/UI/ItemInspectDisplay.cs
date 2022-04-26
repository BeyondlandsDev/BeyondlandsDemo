using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

[Serializable]
public class ItemInspectDisplay
{
    public Image Icon;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI AmountText;
    public TextMeshProUGUI DescriptionText;

    public GridLayoutGroup OptionGrid;
}
