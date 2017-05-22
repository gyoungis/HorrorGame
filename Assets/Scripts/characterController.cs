using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

    //   float jumpSpeed = 8.0f;
    //   float gravity = 20.0f;

    //   public float speed = 10.0f;
    //   //CharacterController controller;
    //   private float vSpeed = -1;

    //   // Use this for initialization
    //   void Start () {
    //       Cursor.lockState = CursorLockMode.Locked;
    //       //controller = GetComponent<CharacterController>();
    //}

    //// Update is called once per frame
    //void Update () {
    //       float translation = Input.GetAxis("Vertical") * speed;
    //       float straffe = Input.GetAxis("Horizontal") * speed;
    //       translation *= Time.deltaTime;
    //       straffe *= Time.deltaTime;



    //       if (Input.GetKeyDown("escape"))
    //           Cursor.lockState = CursorLockMode.None;

    //       //if (controller.isGrounded)
    //       if (gameObject.GetComponent<CharacterController>().isGrounded)
    //       {
    //           vSpeed = -1;
    //           if (Input.GetButtonDown ("Jump"))
    //           {
    //               vSpeed = jumpSpeed * speed * Time.deltaTime;
    //           }

    //       }


    //       transform.Translate(straffe, vSpeed, translation);
    //   }

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
