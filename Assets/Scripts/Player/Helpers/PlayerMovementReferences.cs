using System;
using UnityEngine;

[Serializable]
public class PlayerMovementReferences
{
    [Header("Stat Types")]
    public StatType MoveStat;
    public StatType JumpStat;
    public StatType FallMultiplier;
    public StatType LowJumpMultiplier;
    public FloatReference Gravity;
}
