using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D movableRigidbody;
    private Transform movableTransform;
    private CapsuleCollider2D movableCollider;

    [SerializeField] private float velocityMultiplier = 5f;
    [SerializeField] private float jumpMultiplier = 400f;
    [SerializeField] private float crouchSpeedMultiplier = 0.4f;
    [SerializeField] private float crouchJumpMultiplier = 1.5f;
    [SerializeField] private float crouchHeightMultiplier = 0.5f;
    [Range(0,1)][SerializeField] public float Efficiety = 1f;

    private Vector2 colliderSize;
    private Vector2 colliderOffset;
    private bool crouched = false;

    private RaycastHit2D temp;
    //private RaycastHit2D

    // Start is called before the first frame update
    void Start()
    {
        movableRigidbody = GetComponent<Rigidbody2D>();
        movableTransform = GetComponent<Transform>();
        movableCollider = GetComponent<CapsuleCollider2D>();
        colliderSize = movableCollider.size;
        colliderOffset = movableCollider.offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetKey(KeyCode.S));
    }

    private void Crouch(bool crouch)
    {
        if ((!crouched) && crouch)
        {
            movableCollider.size = new Vector2(colliderSize.x, colliderSize.y * crouchHeightMultiplier);
            movableCollider.offset = colliderOffset + new Vector2(0, -colliderSize.y * crouchHeightMultiplier / 2);
            crouched = true;
        }
        else if ((crouched) && !crouch)
        {
            movableCollider.size = colliderSize;
            movableCollider.offset = colliderOffset;
            crouched = false;
        }
    }

    public void Move(float velocity, float jump, bool crouch)
    {
        Crouch(crouch);
        if (movableRigidbody.velocity.y==0)
        {
            if (crouch)
            {
                velocity *= crouchSpeedMultiplier;
                jump *= crouchJumpMultiplier;

            }
            movableRigidbody.AddForce( new Vector2( 0, jump * jumpMultiplier));
        }
        movableRigidbody.velocity= new Vector2( velocity * velocityMultiplier, movableRigidbody.velocity.y);
    }
}
