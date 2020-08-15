using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Transform))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D movableRigidbody;
    private Transform movableTransform;
    private CapsuleCollider2D movableCollider;

    private readonly float overlapRadius = 0.1f; //radius for collider checking  checking 
    public LayerMask GroundLayer; //define whitch layer is ground
    [SerializeField] private PhysicsMaterial2D stationary; //what material is used when character is stationary
    [SerializeField] private PhysicsMaterial2D moving; //what material is used when character  is moving

    [SerializeField] private float velocityMultiplier = 5f; //adjust horizontal velocity
    [SerializeField] private float jumpMultiplier = 400f; //adjust jump strength
    [SerializeField] private float crouchSpeedMultiplier = 0.4f; //adjust horizontal velocity when crouching
    [SerializeField] private float crouchJumpMultiplier = 1.5f; //adjust jump strength when crouching
    [Range(0f, 1f)] [SerializeField] private float crouchHeightMultiplier = 0.5f; //how much cillider shrinks when crouched

    private Vector2 colliderSize; // normal/original collider size
    private Vector2 colliderOffset; // normal/original collider offset
    private bool crouched = false; //indicates if object is crouched

    // Start is called before the first frame update
    // Setting up poperties
    void Start()
    {
        movableRigidbody = GetComponent<Rigidbody2D>();
        movableTransform = GetComponent<Transform>();
        movableCollider = GetComponent<CapsuleCollider2D>();
        colliderSize = movableCollider.size;
        colliderOffset = movableCollider.offset;
        crouchHeightMultiplier = Math.Max(crouchHeightMultiplier, colliderSize.x / colliderSize.y);
    }

    /// <summary>
    /// checks if there is space around character head height
    /// </summary>
    /// <returns> returns true if u can stand up else false</returns>
    private bool CanStandUp()
    {
        return !Physics2D.OverlapCircle(
            new Vector2(movableTransform.position.x, movableTransform.position.y + colliderOffset.y + (colliderSize.y / 2)),
            overlapRadius, GroundLayer);
    }

    /// <summary>
    /// checks if there is ground beneath character character feet
    /// </summary>
    /// <returns> returns true if character is on ground else false</returns>
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(
            new Vector2(movableTransform.position.x, movableTransform.position.y + colliderOffset.y - (colliderSize.y / 2)),
            overlapRadius, GroundLayer);
    }

    /// <summary>
    /// handlles transition in and out of crouch based on desired state
    /// </summary>
    /// <param name="crouch">desired state</param>
    private void Crouch(bool crouch)
    {
        if (!crouched && crouch)
        {
            movableCollider.size = new Vector2(colliderSize.x, colliderSize.y * crouchHeightMultiplier);
            movableCollider.offset = colliderOffset + new Vector2(0, -colliderSize.y * (1 - crouchHeightMultiplier) / 2); 
            crouched = true;
        }
        else if (crouched && !crouch && CanStandUp())
        {
            movableCollider.size = colliderSize;
            movableCollider.offset = colliderOffset;    
            crouched = false;
        }
    }

    /// <summary>
    /// Move character based on input
    /// </summary>
    /// <param name="direction">horizontal direction of movement</param>
    /// <param name="jump"></param>
    /// <param name="crouch"></param>
    public void Move(float direction, float jump, bool crouch)
    {
        bool grounded = IsGrounded();

        Crouch(crouch);

        if (grounded)
        {
            if (crouched)
            {
                direction *= crouchSpeedMultiplier;
                jump *= crouchJumpMultiplier;
            }
            movableRigidbody.AddForce(new Vector2(0, jump * jumpMultiplier)); 
        }

        if ((direction == 0)&&(grounded))
        {
            movableRigidbody.sharedMaterial = stationary;
        }
        else
        {
            movableRigidbody.sharedMaterial = moving;
        }

        movableRigidbody.velocity = new Vector2(direction * velocityMultiplier, movableRigidbody.velocity.y);
    }
}
