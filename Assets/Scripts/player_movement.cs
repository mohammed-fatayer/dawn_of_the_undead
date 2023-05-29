using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public CharacterController  controller;
    public float speed =5f;

    Vector3 velocity;
    public float gravity = -9.81f;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundmask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         isGrounded = Physics.CheckSphere(groundCheck.position ,groundDistance,groundmask);
         if(isGrounded && velocity.y < 0)
         {
            velocity.y = -2f;
         }
        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        velocity.y +=gravity * Time.deltaTime;

        controller.Move(velocity *Time.deltaTime);




        
    }
}
