using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int Ground;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform heightCheck;
    [SerializeField] private LayerMask wallLayer;


    private float attackRadius = 1f;
    private int attackDamage = 1;
    private int TimeBetweenAttacks = 100;
    private int DmgCounter = 0;
    private float horizontal;
    private float speed = 10f;
    private bool isFacingRight = true;
    private int Seen = 0;
    private int ForgetTime = 1000;
    private float jumpingPower = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Seen > 0)
        {
            if (Target.position.x > rb.position.x)
            {
                horizontal = 1;
            }
            else if (Target.position.x < rb.position.x)
            {
                horizontal = -1;
            }
        }
        else
        {
            horizontal = 0;
        }
        Flip();
        //if it's next to a wall, and not currently vertically moving
        if ((rb.velocity.y == 0) && IsAbleToJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        
    }
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, (Target.position-transform.position), Vector2.Distance(Target.position, transform.position), 1<<Ground) || Vector2.Distance(Target.position, transform.position) > 1000f)
        {
            if (Seen > 0)
            {
                Seen--;
            }
        }
        else
        {
            Seen = ForgetTime;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        
        if (DmgCounter == 0)
        {
            if (Vector2.Distance(transform.position, Target.position) < attackRadius)
            {
                playerHealth.Damage(attackDamage);
                DmgCounter = TimeBetweenAttacks;
                //playerMovement.Knockback(transform.position - Target.position);
                //Debug.Log(transform.position - Target.position);
            }
        }
        else
        {
            DmgCounter--;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsAbleToJump()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer) && ! Physics2D.OverlapCircle(heightCheck.position, 0.2f, wallLayer);
    }
}
