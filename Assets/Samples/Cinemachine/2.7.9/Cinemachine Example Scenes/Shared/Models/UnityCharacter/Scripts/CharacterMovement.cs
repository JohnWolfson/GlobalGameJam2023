using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Examples
{

[AddComponentMenu("")] // Don't display in add component menu
public class CharacterMovement : MonoBehaviour
{
    /*
    public bool useCharacterForward = false;
    public bool lockToCameraForward = false;
    public float turnSpeed = 10f;
    public KeyCode sprintJoystick = KeyCode.JoystickButton2;
    public KeyCode sprintKeyboard = KeyCode.Space;

    private float turnSpeedMultiplier;
    public float speed = 0f;
    private float direction = 0f;
    private bool isSprinting = false;
    private Animator anim;
    private Vector3 targetDirection;
    private Vector2 input;
    private Quaternion freeRotation;
    private Camera mainCamera;
    private float velocity;
    int isAimingParam = Animator.StringToHash("isAiming"); 

	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	    mainCamera = Camera.main;
	}

    void Update()
    {
        bool isAiming = Input.GetMouseButton(1);
        anim.SetBool(isAimingParam, isAiming); 
    }

	// Update is called once per frame
	void FixedUpdate ()
	{
	    input.x = Input.GetAxis("Horizontal");
	    input.y = Input.GetAxis("Vertical");

		// set speed to both vertical and horizontal inputs
        if (useCharacterForward)
            speed = Mathf.Abs(input.x) + input.y;
        else
            speed = Mathf.Abs(input.x) + Mathf.Abs(input.y);

        speed = Mathf.Clamp(speed, 0f, 1f);
        speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref velocity, 0.1f);
        anim.SetFloat("Speed", speed);

	    if (input.y < 0f && useCharacterForward)
            direction = input.y;
	    else
            direction = 0f;

        anim.SetFloat("Direction", direction);

        if(velocity <= 0)
        {
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("Moving", true);
        }
        //add this to the moving bit in a if else, set to false when not moving 
        // set sprinting
	    isSprinting = ((Input.GetKey(sprintJoystick) || Input.GetKey(sprintKeyboard)) && input != Vector2.zero && direction >= 0f);
        anim.SetBool("isSprinting", isSprinting);

        // Update target direction relative to the camera view (or not if the Keep Direction option is checked)
        UpdateTargetDirection();
        if (input != Vector2.zero && targetDirection.magnitude > 0.1f)
        {
            Vector3 lookDirection = targetDirection.normalized;
            freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
            var diferenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
            var eulerY = transform.eulerAngles.y;

            if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
            var euler = new Vector3(0, eulerY, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), turnSpeed * turnSpeedMultiplier * Time.deltaTime);
        }
	}

    public virtual void UpdateTargetDirection()
    {
        if (!useCharacterForward)
        {
            turnSpeedMultiplier = 1f;
            var forward = mainCamera.transform.TransformDirection(Vector3.forward);
            forward.y = 0;

            //get the right-facing direction of the referenceTransform
            var right = mainCamera.transform.TransformDirection(Vector3.right);

            // determine the direction the player will face based on input and the referenceTransform's right and forward directions
            targetDirection = input.x * right + input.y * forward;
        }
        else
        {
            turnSpeedMultiplier = 0.2f;
            var forward = transform.TransformDirection(Vector3.forward);
            forward.y = 0;

            //get the right-facing direction of the referenceTransform
            var right = transform.TransformDirection(Vector3.right);
            targetDirection = input.x * right + Mathf.Abs(input.y) * forward;
        }
    }*/
    public CharacterController controller; 
    public float mouseSens = 100f; 
    public Transform playerBody; 
    float xRotation = 0f; 
    public float speed = 12f;
    //public float MinLookUpAngle;
    //public float MaxLookUpAngle;
    private float yRotate = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
            //float mouseX = Input.GetAxisRaw("Mouse X") * mouseSens * Time.deltaTime;
            //////yRotate += Input.GetAxisRaw("Mouse Y") * mouseSens * Time.deltaTime;
            //////yRotate = Mathf.Clamp(yRotate, MinLookUpAngle, MaxLookUpAngle);
            //////transform.eulerAngles = new Vector3(yRotate, 0, 0);

        //xRotation -= mouseY;
            //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            //playerBody.Rotate(Vector3.up * (mouseY + mouseX)); 

            //playerBody.Rotate(Mathf.Clamp(Vector3.up * (mouseY + mouseX), -35f, 70f));



        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; 
        controller.Move(move* speed * Time.deltaTime); 


    }
}



}
