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

    public PlayerMouseLook mouseLook;
    public PlayerMovement movement;
    public PlayerStatHelper statHelper;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player.MovementStat.CurrentValue = Player.MovementStat.WalkSpeed;
        movement = new PlayerMovement(Player, transform);
        mouseLook = new PlayerMouseLook(Player, transform);
        statHelper = new PlayerStatHelper(Player);
    }

    void Update()
    {
        movement.Move();

        mouseLook.MouseLook();

        TargetInfo.CheckForTarget(Player.PlayerCamera);

        Player.MovementStat.DoUpdate();
        Player.StaminaStat.DoUpdate();
        Player.HealthStat.DoUpdate();

        statHelper.Tick();

        // Player.HungerStat.DoUpdate();
        // Player.ThirstStat.DoUpdate();

        if (Player.StaminaStat.IsFatigued)
            StartCoroutine(FatigueCoolDown());
    }

    private IEnumerator FatigueCoolDown()
    {
        yield return new WaitForSeconds(3f);
        Player.StaminaStat.IsFatigued = false;
    }

}

