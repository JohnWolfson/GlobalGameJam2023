using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller; 
    public Transform camera; 
    public float speed = 6f; 
    public float gravity = -9.81f; 
    private Vector3 velocity; 
    public float jumpHeight = 1.0f; 
    private bool groundedPlayer; 
    public float turnSmoothTime = 0.1f; 

    float turnSmoothVel; 
    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f; 
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical"); 
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; 
        velocity.y += gravity * Time.deltaTime; 
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y; 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime); 
            transform.rotation = Quaternion.Euler(0f, angle, 0f); 

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed + velocity * Time.deltaTime); 
        }
        controller.Move(velocity *Time.deltaTime); 
    }
}
