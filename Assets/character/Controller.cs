using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Transform))]
public class Controller : MonoBehaviour, IController
{
    private Rigidbody2D movableRigidbody;
    private Transform movableTransform;
    private CapsuleCollider2D movableCollider;

    private Vector2 colliderSize; // normal/original collider size
    private Vector2 colliderOffset; // normal/original collider offset
    private float overlapRadius = 0.1f; //Change  radius for collider checking  checking 

    public LayerMask GroundLayer; //define whitch layer is ground

    [SerializeField] private float velocityMultiplier = 5f; //adjust horizontal velocity
    [SerializeField] private float jumpMultiplier = 400f; //adjust jump strength
    [SerializeField] private float crouchSpeedMultiplier = 0.4f; //adjust horizontal velocity when crouching
    [SerializeField] private float crouchJumpMultiplier = 1.5f; //adjust jump strength when crouching
    [Range(0f, 1f)] [SerializeField] private float crouchHeightMultiplier = 0.5f; //how much cillider shrinks when crouched

    public bool Crouched { get; private set; } = false; //indicates if object is crouched
    public bool Grounded { get; private set; }       //indicates if object is standing on ground 
    private bool right = true;

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
        Grounded = IsGrounded();
        overlapRadius *= movableTransform.localScale.y;
        movableTransform.localScale = new Vector2(Math.Abs( movableTransform.localScale.x),movableTransform.localScale.y);
    }

    void FixedUpdate()
    {
        Grounded = IsGrounded();
    }

    /// <summary>
    /// checks if there is space around character head height
    /// </summary>
    /// <returns> returns true if u can stand up else false</returns>
    private bool CanStandUp()
    {
        return !Physics2D.OverlapCircle(
            new Vector2(movableTransform.position.x, movableTransform.position.y + (colliderOffset.y + (colliderSize.y / 2)) * movableTransform.localScale.y),
            overlapRadius, GroundLayer);
    }

    /// <summary>
    /// checks if there is ground beneath character character feet
    /// </summary>
    /// <returns> returns true if character is on ground else false</returns>
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(
            new Vector2(movableTransform.position.x, movableTransform.position.y + (colliderOffset.y - (colliderSize.y / 2)) * movableTransform.localScale.y),
            overlapRadius, GroundLayer);


        //return Physics2D.OverlapCircle(
        //    new Vector2(movableTransform.position.x, movableTransform.position.y + (colliderOffset.y - ((colliderSize.y - colliderSize.x * 0.4f) / 2)) * movableTransform.localScale.y - overlapRadius),
        //    colliderSize.x * 0.4f, GroundLayer);

        //return Physics2D.OverlapBox(new Vector2(movableTransform.position.x, movableTransform.position.y + (colliderOffset.y - (colliderSize.y / 2)) * movableTransform.localScale.y),
        //    new Vector2(colliderSize.x * 0.3f, overlapRadius) * movableTransform.localScale.y, 0, GroundLayer);
    }

    private void Flip()
    {
        right = !right;
        movableTransform.localScale = new Vector2(-movableTransform.localScale.x, movableTransform.localScale.y);

    }
    /// <summary>
    /// handlles transition in and out of crouch based on desired state
    /// </summary>
    /// <param name="crouch">desired state</param>
    public void Crouch(bool crouch)
    {
        //crouch
        if (!Crouched && crouch)
        {
            movableCollider.size = new Vector2(colliderSize.x, colliderSize.y * crouchHeightMultiplier);
            movableCollider.offset = colliderOffset + new Vector2(0, -colliderSize.y * (1 - crouchHeightMultiplier) / 2); 
            Crouched = true;
        }
        //uncrouch
        else if (Crouched && !crouch && CanStandUp())
        {
            movableCollider.size = colliderSize;
            movableCollider.offset = colliderOffset;    
            Crouched = false;
        }
    }

    /// <summary>
    /// Makes character jump based on input
    /// </summary>
    /// <param name="jump"></param>
    public void Jump(float jump)
    {
        if ( Grounded)
        {
            //adjust power
            if (Crouched)
            {
                jump*= crouchJumpMultiplier;
            }
            //negate prejump upvards velocity
            if (movableRigidbody.velocity.y > 0 )
            {
                movableRigidbody.velocity = new Vector2(movableRigidbody.velocity.x,0);
            }
            movableRigidbody.AddForce(new Vector2(0, jump * jumpMultiplier));
        }
    }

    /// <summary>
    /// Move character in given direction
    /// </summary>
    /// <param name="direction">horizontal direction of movement</param>
    public void Move(float direction)
    {
        //flip to the right side
        if (right && (direction < 0))
        {
            Flip();
        }
        else if (!right && (direction > 0))
        {
            Flip();
        }

        //prevent rotation
        movableRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (Grounded)
        {
            //stop sliding
            if (Utils.FloatEquality(direction,0))
            {
                movableRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            //adjust velocity
            if (Crouched)
            {
                direction *= crouchSpeedMultiplier;
            }
        }
        //move
        movableRigidbody.velocity = new Vector2(direction * velocityMultiplier, movableRigidbody.velocity.y);
    }
}
