using System;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newHealthStat", menuName = "Stats/Health Stat")]
public class HealthStat : SurvivalStat
{
    [SerializeField]
    private bool isDead = false;
    public bool IsDead { get => isDead; set => isDead = value; }

    public override void OnEnable()
    {
        base.OnEnable();
        IsDead = false;
    }

    public override void DoUpdate()
    {
        base.DoUpdate();
    }
}
