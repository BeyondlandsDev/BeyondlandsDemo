using System;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newHungerStat", menuName = "Stats/Hunger Stat")]
public class HungerStat : Stat
{
    [SerializeField]
    private float hungerDrain;
    public float HungerDrain { get => hungerDrain; set => hungerDrain = value; }

    [SerializeField]
    private float hungerRegen;
    public float HungerRegen { get => hungerRegen; set => hungerRegen = value; }

    [SerializeField]
    private bool isStarving;
    public bool IsStarving { get => isStarving; set => isStarving = value; }

    public override void DoUpdate()
    {
        DoStatTick();
    }

    private void DoStatTick()
    {
        if (CurrentValue > 0)
            CurrentValue -= HungerDrain * Time.deltaTime;
        else
            IsStarving = true;
    }
}
