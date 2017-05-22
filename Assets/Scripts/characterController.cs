using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
    bool isSprinting = false;

    public float speed = 6.0F;
    public float sprintSpeed = 12.0f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        // Hides mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            // Determines movement of player
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            // Changes speed to Sprinting
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
            }

            if (isSprinting)
            {
                speed = sprintSpeed;
            }
            else
            {
                speed = 6.0f;
            }

            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }

        // Final player Movement
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
