using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_StatDisplay : MonoBehaviour
{
    public Stat Stat;

    [SerializeField]
    //private Image bar;
    private TMP_Text text;

    private void Update()
    {
        UpdateStat();
    }

    public void UpdateStat()
    {
        text.text = (Stat.CurrentValue).ToString();
    }
}
