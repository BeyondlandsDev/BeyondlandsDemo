using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public PlayerReferences Player = new PlayerReferences();
    public PlayerMovementReferences MovementRef = new PlayerMovementReferences();

    [Header("Targeting")]
    public PlayerTarget TargetInfo;

    public PlayerMouseLook mouseLook = new PlayerMouseLook();
    public PlayerMovement movement = new PlayerMovement();

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        movement.Move(transform, Player.CharacterController,
            StatValue(MovementRef.MoveStat), StatValue(MovementRef.JumpStat), MovementRef.Gravity, 
            Player.GroundCollider, Player.GroundMask, StatValue(MovementRef.FallMultiplier), 
            StatValue(MovementRef.LowJumpMultiplier));

        mouseLook.MouseLook(Player.PlayerCamera, transform,
            Player.GameSettings.MouseSensitivity);

        TargetInfo.CheckForTarget(Player.PlayerCamera);
    }

    public float StatValue(StatType statType)
    {
        return Player.PlayerStats.Get(statType).CurrentValue;
    }
}

