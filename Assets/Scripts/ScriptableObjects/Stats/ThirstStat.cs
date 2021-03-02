using System;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newThirstStat", menuName = "Stats/Thirst Stat")]
public class ThirstStat : Stat
{
    [SerializeField]
    private float thirstTick;
    public float ThirstTick { get => thirstTick; }

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
            CurrentValue -= thirstTick * Time.deltaTime;
        else
            IsDehydrated = true;
    }
}
