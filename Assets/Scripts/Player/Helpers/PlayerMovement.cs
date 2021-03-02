using UnityEngine;

public class PlayerMovement
{
    private Vector3 velocity;

    public void Move(Transform transform, CharacterController characterController, 
        float moveSpeed, float jumpHeight, float gravity, Transform groundCollider, 
        LayerMask groundMask, float fallMultiplier, float lowJumpMulitpier)
    {
        float groundDistance = 0.4f;


        //float jumpHeight = 8f;

        bool isGrounded = Physics.CheckSphere(groundCollider.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        //WALKING
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        //JUMPING
        velocity.y += gravity* Time.deltaTime;
        characterController.Move(velocity* Time.deltaTime);

        if (velocity.y < 0)
            velocity += Vector3.up* gravity* (fallMultiplier - 1) * Time.deltaTime;
        else if (velocity.y > 0 && !Input.GetButton("Jump"))
            velocity += Vector3.up* gravity * (lowJumpMulitpier - 1) * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
            velocity.y = Mathf.Sqrt(jumpHeight* -2f * gravity);

    }
}
