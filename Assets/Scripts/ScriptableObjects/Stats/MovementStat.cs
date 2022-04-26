using System;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newMovementStat", menuName = "Stats/Movement Stat")]
public class MovementStat : Stat
{
    [SerializeField]
    private float walkSpeed;
    public float WalkSpeed { get => walkSpeed; }

    [SerializeField]
    private float runSpeed;
    public float RunSpeed { get => runSpeed; }

    [SerializeField]
    private float jumpHeight;
    public float JumpHeight { get => jumpHeight; }

    [SerializeField]
    private float fallMultiplier;
    public float FallMultiplier { get => fallMultiplier; }

    [SerializeField]
    private float lowJumpMultiplier;
    public float LowJumpMultiplier { get => lowJumpMultiplier; }

    public override void DoUpdate()
    {
        //nothing yet
    }
}