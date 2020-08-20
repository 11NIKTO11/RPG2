using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Controller controller;
    public Animator animator;
    new private Rigidbody2D rigidbody;

    private float direction;
    private float jump;
    private bool crouch;

    private float efficiecy = 1;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //read input
        direction = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");
        crouch = Input.GetKey(KeyCode.S);
        //animate
        animator.SetFloat("Horizontal Velocity", Mathf.Abs(direction));
        animator.SetFloat("Vertical Velocity", rigidbody.velocity.y);
        animator.SetBool("Grounded", controller.Grounded);
        animator.SetBool("Crouched", controller.Crouched);
    }

    void FixedUpdate()
    {
        controller.Move(direction);
        controller.Jump(jump);
        controller.Crouch(crouch);
         
    }
}
