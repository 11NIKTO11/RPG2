using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Controller controller;
    public Animator animator;
    public Attacker attacker;
    new private Rigidbody2D rigidbody;

    private float direction;
    private float jump;
    private bool crouch;

    private bool attack;

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
        //attack
        attack = Input.GetKeyDown(KeyCode.Mouse0);
        if (attack)
        {
            attacker.Attack();
        }

        //animate
        animator.SetFloat("Horizontal Velocity", Mathf.Abs(direction));
        animator.SetFloat("Vertical Velocity", rigidbody.velocity.y);
        animator.SetBool("Grounded", controller.Grounded);
        animator.SetBool("Crouched", controller.Crouched);
        animator.SetBool("Attack", attack);
    }

    void FixedUpdate()
    {
        controller.Move(direction);
        controller.Jump(jump);
        controller.Crouch(crouch);
    }
}
