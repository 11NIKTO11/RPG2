using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contorler : MonoBehaviour
{
    public Movement movement;
    private float direction;
    private float jump;
    private bool crouch;

    private float efficiecy = 1;

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");
        Debug.Log(jump);
        crouch = Input.GetKey(KeyCode.S);

    }

    void FixedUpdate()
    {
        movement.Move(direction * efficiecy, jump * efficiecy, crouch);
    }
}
