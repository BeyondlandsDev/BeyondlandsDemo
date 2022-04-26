using System;
using UnityEngine;

[Serializable]
public class PlayerMovementReferences
{
    [Header("Movement Stats")]
    public Stat MoveStat;
    public Stat JumpStat;
    public Stat FallMultiplier;
    public Stat LowJumpMultiplier;
    public FloatReference Gravity;
}
