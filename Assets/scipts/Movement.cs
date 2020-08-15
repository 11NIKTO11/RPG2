using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D movableRigidbody;
    private Transform movableTransform;
    private CapsuleCollider2D movableCollider;
    private float overlapRadius = 0.1f;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private PhysicsMaterial2D stationary;
    [SerializeField] private PhysicsMaterial2D moving;

    [Min(0)] [SerializeField] private float stationaryFriction = 10f;
    [Min(0)] [SerializeField] private float movingFriction = 0f;

    [SerializeField] private float velocityMultiplier = 5f;
    [SerializeField] private float jumpMultiplier = 400f;
    [SerializeField] private float crouchSpeedMultiplier = 0.4f;
    [SerializeField] private float crouchJumpMultiplier = 1.5f;
    [Range(0f, 1f)] [SerializeField] private float crouchHeightMultiplier = 0.5f;
    [Range(0f, 1f)] [SerializeField] public float Efficiety = 1f;

    private Vector2 colliderSize;
    private Vector2 colliderOffset;
    private bool crouched = false;

    // Start is called before the first frame update
    void Start()
    {
        movableRigidbody = GetComponent<Rigidbody2D>();
        movableTransform = GetComponent<Transform>();
        movableCollider = GetComponent<CapsuleCollider2D>();
        colliderSize = movableCollider.size;
        colliderOffset = movableCollider.offset;
        crouchHeightMultiplier = Math.Max(crouchHeightMultiplier, colliderSize.x / colliderSize.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetKey(KeyCode.S));
    }

    private void Crouch(bool crouch)
    {
        if (!crouched && crouch)
        {
            movableCollider.size = new Vector2(colliderSize.x, colliderSize.y * crouchHeightMultiplier);
            movableCollider.offset = colliderOffset + new Vector2(0, -colliderSize.y * (1 - crouchHeightMultiplier) / 2);
            crouched = true;
        }
        else if (crouched && !crouch && !Physics2D.OverlapCircle(new Vector2(movableTransform.position.x, movableTransform.position.y + colliderOffset.y + (colliderSize.y / 2)), overlapRadius, whatIsGround))
        {
            movableCollider.size = colliderSize;
            movableCollider.offset = colliderOffset;
            crouched = false;
        }
    }

    public void Move(float velocity, float jump, bool crouch)
    {
        bool grounded = Physics2D.OverlapCircle(new Vector2(movableTransform.position.x, movableTransform.position.y + colliderOffset.y - (colliderSize.y / 2)), overlapRadius, whatIsGround);

        Crouch(crouch);

        if (grounded)
        {
            if (crouch)
            {
                velocity *= crouchSpeedMultiplier;
                jump *= crouchJumpMultiplier;
            }
            movableRigidbody.AddForce(new Vector2(0, jump * jumpMultiplier));
        }

        if ((velocity == 0)&&(grounded))
        {
            movableRigidbody.sharedMaterial = stationary;
            Debug.Log("stationary");
        }
        else
        {
            movableRigidbody.sharedMaterial = moving;
            Debug.Log("moving");
        }

        movableRigidbody.velocity = new Vector2(velocity * velocityMultiplier, movableRigidbody.velocity.y);
    }
}
