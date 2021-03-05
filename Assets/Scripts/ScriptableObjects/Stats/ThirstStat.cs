using System;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newThirstStat", menuName = "Stats/Thirst Stat")]
public class ThirstStat : Stat
{
    [SerializeField]
    private float thirstDrain;
    public float ThirstDrain { get => thirstDrain; set => thirstDrain = value; }

    [SerializeField]
    private float thirstRegen;
    public float ThirstRegen { get => thirstRegen; set => thirstRegen = value; }

    [SerializeField]
    private bool isDehydrated;
    public bool IsDehydrated { get => isDehydrated; set => isDehydrated = value; }

    public override void DoUpdate()
    {
        DoStatTick();
    }

    private void DoStatTick()
    {
        if (CurrentValue > 0)
            CurrentValue -= thirstDrain * Time.deltaTime;
        else
            IsDehydrated = true;
    }
}
