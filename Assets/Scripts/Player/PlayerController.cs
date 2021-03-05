using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public PlayerReferences Player = new PlayerReferences();
    //public PlayerMovementReferences MovementRef = new PlayerMovementReferences();

    [Header("Targeting")]
    public PlayerTarget TargetInfo;

    public PlayerMouseLook mouseLook = new PlayerMouseLook();
    public PlayerMovement movement = new PlayerMovement();

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player.MovementStat.CurrentValue = Player.MovementStat.WalkSpeed;
    }

    void Update()
    {
        movement.Move(transform, Player.CharacterController,
            Player.MovementStat, Player.StaminaStat, Player.Gravity, 
            Player.GroundCollider, Player.GroundMask);

        mouseLook.MouseLook(Player.PlayerCamera, transform,
            Player.GameSettings.MouseSensitivity);

        TargetInfo.CheckForTarget(Player.PlayerCamera);

        Player.MovementStat.DoUpdate();
        Player.StaminaStat.DoUpdate();

        if (Player.StaminaStat.IsFatigued)
            StartCoroutine(FatigueCoolDown());
    }

    private IEnumerator FatigueCoolDown()
    {
        yield return new WaitForSeconds(3f);
        Player.StaminaStat.IsFatigued = false;
    }

}

