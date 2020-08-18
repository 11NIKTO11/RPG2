using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Controller controller;
    public Animator animator;

    private float direction;
    private float jump;
    private bool crouch;

    private float efficiecy = 1;
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");
        crouch = Input.GetKey(KeyCode.S);

        animator.SetFloat("horizontal speed", Mathf.Abs( direction));
    }

    void FixedUpdate()
    {
        controller.Move(direction);
        controller.Jump(jump);
        controller.Crouch(crouch);
         
    }
}
