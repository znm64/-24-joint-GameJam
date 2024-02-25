using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform heightCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private GameObject jumpParticles;

    private int walkDuration = 75;
    private int walkTime;
    private float horizontal;
    private float speed = 2f;
    private bool isFacingRight = true;
    //change this back to 12 after testing
    private float jumpingPower = 14f;
    //this delay count ensures that the jump works correctly
    private int delayCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        walkTime = walkDuration;
    }

    // Update is called once per frame
    void Update()
    {
        delayCount++;
        
        //if it's next to a wall, able to jump over it, grounded, and on a sufficient cooldown

        if (delayCount > 90 && IsAbleToJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            delayCount = 0;
            Instantiate(jumpParticles, groundCheck.position, Quaternion.identity);
        }
        Flip();

    }
    private void FixedUpdate()
    {
        if (walkTime > 2) { walkTime--; }

        if (UnityEngine.Random.Range(0, walkTime) == 0)
        {
            walkTime = walkDuration;
            if (horizontal == 1) { horizontal--; }
            else if (horizontal == 0) { horizontal += UnityEngine.Random.Range(-1, 2); }
            else if (horizontal == -1) { horizontal++; }
        }
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsAbleToJump()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, wallLayer) && Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer) && !Physics2D.OverlapCircle(heightCheck.position, 0.2f, wallLayer) && (horizontal > 0);
    }
}
