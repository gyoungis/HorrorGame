using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour {

    CharacterController controller;
    bool isSprinting = false;
    bool crouching = false;
    bool outOfBreath = false;
    float stamina = 100f;

    public float playerHeight = 2.0f;
    private float speed = 5.0F;
    private float sprintSpeed = 8.0f;
    private float crouchSpeed = 3.0f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float pickupDist = 4.0f;
    public Slider slider;

    private Camera fpsCam;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        fpsCam = GetComponentInChildren<Camera>();

        // Hides mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.6f));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, pickupDist))
            {
                Note state = hit.collider.GetComponent<Note>();
                if (state != null)
                {
                    state.pickedUp(1);
                    state.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.0f;
                }
            }
        }


        if (controller.isGrounded)
        {
            // Determines movement of player
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            // Changes speed to Sprinting

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (outOfBreath == false)
                {
                    isSprinting = true;
                    stamina = stamina - Time.deltaTime * 15.0f;
                    if (stamina < 0)
                    {
                        outOfBreath = true;
                    }
                }
            }
            else
            {
                isSprinting = false;
            }


            if (outOfBreath == true || isSprinting == false)
            {
                stamina = stamina + Time.fixedDeltaTime * 5.0f;
                if (stamina > 100)
                {
                    outOfBreath = false;
                }
            }
            slider.value = stamina;
            // Player Crouching
            if (Input.GetKey(KeyCode.LeftControl))
            {
                crouch();
                isSprinting = false;
            }
            else
            {
                standing();
            }

            // Changes player speed according to current state
            if (isSprinting)
            {
                speed = sprintSpeed;
            }
            else if (crouching)
            {
                speed = crouchSpeed;
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

    void crouch()
    {
        controller.height = playerHeight / 2.0f;
        crouching = true;
    }

    void standing()
    {
        controller.height = playerHeight;
        crouching = false;
    }
}
