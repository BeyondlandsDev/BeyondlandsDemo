using System;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newHealthStat", menuName = "Stats/Health Stat")]
public class HealthStat : Stat
{
    [SerializeField]
    private bool isAlive = true;
    public bool IsAlive { get => isAlive; set => isAlive = value; }

    public override void DoUpdate()
    {
        IsAliveCheck();
    }

    public void IsAliveCheck()
    {
        if (CurrentValue <= 0)
            isAlive = false;
        else
            isAlive = true;
    }
}
