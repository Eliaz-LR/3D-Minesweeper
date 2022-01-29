using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded va être set par un check d'un sphere de collision definie si dessous
        isGrounded=Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y=-2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //transform = coordonnées relatives. Vector3 = coordonnées absolues.
        Vector3 move = transform.right*x + transform.forward*z;

        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //la formule suivante permet d'avoir la vitesse requise pour atteindre pile jumpHeight.
            velocity.y=Mathf.Sqrt(jumpHeight*-2f*gravity);
        }

        //Gravité = acceleration = vitesse*temps² (le ² est fait en multipliant par le temps deux fois)
        velocity.y += gravity*Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);
    }
}