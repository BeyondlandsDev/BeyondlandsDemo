using UnityEngine;
using System.Collections;

public class PlayerMovement
{
    private Vector3 velocity;
    //public float CurrentSpeed;
    private Transform transform;
    private CharacterController characterController;
    private MovementStat moveStat;
    private StaminaStat staminaStat;
    private float gravity;
    private Transform groundCollider;
    private LayerMask groundMask;

    public PlayerMovement(PlayerReferences playerRef, Transform playerTransform)
    {
        transform = playerTransform;
        characterController = playerRef.CharacterController;
        moveStat = playerRef.MovementStat;
        staminaStat = playerRef.StaminaStat;
        gravity = playerRef.Gravity;
        groundCollider = playerRef.GroundCollider;
        groundMask = playerRef.GroundMask;
    }

    public void Move()
    {
        float groundDistance = 0.4f;

        bool isGrounded = Physics.CheckSphere(groundCollider.position, groundDistance, groundMask);
        bool isMoving;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            isMoving = true;
        else
            isMoving = false;

        //WALKING
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        characterController.Move(moveDirection * moveStat.CurrentValue * Time.deltaTime);

        //JUMPING
        velocity.y += gravity* Time.deltaTime;
        characterController.Move(velocity* Time.deltaTime);

        if (velocity.y < 0)
            velocity += Vector3.up* gravity* (moveStat.FallMultiplier - 1) * Time.deltaTime;
        else if (velocity.y > 0 && !Input.GetButton("Jump"))
            velocity += Vector3.up* gravity * (moveStat.LowJumpMultiplier - 1) * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
            velocity.y = Mathf.Sqrt(moveStat.JumpHeight* -2f * gravity);

        //RUNNING
        if (Input.GetButton("Sprint") && !staminaStat.IsFatigued && isMoving == true)
        {
            moveStat.CurrentValue = moveStat.RunSpeed;
            staminaStat.IsRunning = true;
        }
        else
        {
            moveStat.CurrentValue = moveStat.WalkSpeed;
            staminaStat.IsRunning = false;
        }
        
        // if (!staminaStat.IsFatigued)
        // {
        // }

        // if (staminaStat.IsFatigued)
        // {
        //     moveStat.CurrentValue = moveStat.WalkSpeed;
        //     //StartCoroutine(FatigueCoolDown(staminaStat));
        // }

    }


}
