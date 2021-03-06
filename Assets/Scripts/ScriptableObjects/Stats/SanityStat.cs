using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newSanityStat", menuName = "Stats/Sanity Stat")]
public class SanityStat : SurvivalStat
{
    [SerializeField]
    private bool isInsane;
    public bool IsInsane { get => isInsane; set => isInsane = value; }

    public override void OnEnable()
    {
        base.OnEnable();
        IsInsane = false;
    }

    public override void DoUpdate()
    {
        base.DoUpdate();
    }
}
