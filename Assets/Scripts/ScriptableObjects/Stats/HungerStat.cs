using System;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newHungerStat", menuName = "Stats/Hunger Stat")]
public class HungerStat : Stat
{
    [SerializeField]
    private float hungerTick;
    public float HungerTick { get => hungerTick; }

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
            CurrentValue -= HungerTick * Time.deltaTime;
        else
            IsStarving = true;
    }
}
