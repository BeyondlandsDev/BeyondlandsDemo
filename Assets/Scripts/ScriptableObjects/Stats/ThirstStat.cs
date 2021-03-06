using System;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newThirstStat", menuName = "Stats/Thirst Stat")]
public class ThirstStat : SurvivalStat
{
    [SerializeField]
    private bool isDehydrated;
    public bool IsDehydrated { get => isDehydrated; set => isDehydrated = value; }

    public override void OnEnable()
    {
        base.OnEnable();
        IsDehydrated = false;
    }

    public override void DoUpdate()
    {
        base.DoUpdate();
    }
}
