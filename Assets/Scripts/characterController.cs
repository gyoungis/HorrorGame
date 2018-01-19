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
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public Slider slider;
    

    private float speed = 4.0f;
    private float walkingSpeed = 4.0f;
    private float sprintSpeed = 6.0f;
    private float crouchSpeed = 2.0f;
    private float sprintDelay = 1.0f;
    private float sprintable;
    
    
    private Vector3 moveDirection = Vector3.zero;

    //Audio
    AudioSource[] audio;
    public bool was_sprinting = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        audio = GetComponentsInChildren<AudioSource>();

        // Hides mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (controller.isGrounded)
        {
            // Determines movement of player
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            // Changes speed to Sprinting

            if (Input.GetKey(KeyCode.LeftShift) && Time.time > sprintable)
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

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (Time.time > sprintable)
                {
                    sprintable = Time.time + sprintDelay;
                    Debug.Log(Time.time);
                    Debug.Log(sprintable);
                }
            }

            if (outOfBreath == true || isSprinting == false)
            {
                stamina = stamina + Time.fixedDeltaTime * 5.0f;
                if (stamina > 100)
                {
                    outOfBreath = false;
                    stamina = 100;
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
                speed = walkingSpeed;
            }

            moveDirection *= speed;
            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
                audio[3].Play();
            }

            if (!was_sprinting && isSprinting)
            {
                audio[1].Play();
            }

            if (was_sprinting && !isSprinting)
            {
                audio[1].Stop();
                audio[2].Play();
            }

        }

        if (isSprinting)
        {
            was_sprinting = true;
        }
        else
        {
            was_sprinting = false;
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
