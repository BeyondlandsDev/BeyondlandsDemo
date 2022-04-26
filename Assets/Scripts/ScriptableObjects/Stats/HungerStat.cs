using System;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newHungerStat", menuName = "Stats/Hunger Stat")]
public class HungerStat : SurvivalStat
{
    [SerializeField]
    private bool isStarving;
    public bool IsStarving { get => isStarving; set => isStarving = value; }

    public override void OnEnable()
    {
        base.OnEnable();
        IsStarving = false;
    }

    public override void DoUpdate()
    {
        base.DoUpdate();
    }
}
