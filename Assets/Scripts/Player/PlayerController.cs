using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, IHasInventory
{
    [Header("References")]
    public PlayerReferences Player = new PlayerReferences();
    //public PlayerMovementReferences MovementRef = new PlayerMovementReferences();

    [Header("Targeting")]
    public PlayerTarget TargetInfo;

    public PlayerMouseLook MouseLook;
    public PlayerMovement Movement;
    public PlayerStatHelper StatHelper;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player.MovementStat.CurrentValue = Player.MovementStat.WalkSpeed;
        TargetInfo = new PlayerTarget(Player);
        Movement = new PlayerMovement(Player, transform);
        MouseLook = new PlayerMouseLook(Player, transform);
        StatHelper = new PlayerStatHelper(Player);
        Player.PlayerTransform.TransformDirection(Vector3.forward);
        //MouseLook.LookAhead();
        //Player.Inventory.Player = this;
    }

    void Update()
    {
        Movement.Move();

        MouseLook.MouseLook();

        TargetInfo.CheckForTarget();

        Player.MovementStat.DoUpdate();
        Player.StaminaStat.DoUpdate();
        Player.HealthStat.DoUpdate();

        StatHelper.Tick();

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

