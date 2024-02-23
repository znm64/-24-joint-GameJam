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
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Animator animator;


    private float attackRadius = 1.2f;
    private int attackDamage = 1;
    private int TimeBetweenAttacks = 50;
    private int DmgCounter = 0;
    private float horizontal;
    private float speed = 2f;
    private bool isFacingRight = true;
    private int Seen = 0;
    private int ForgetTime = 1000;
    //change this back to 12 after testing
    private float jumpingPower = 12f;
    //this delay count ensures that the jump works correctly
    private int delayCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mathf.Abs(Target.position.x - transform.position.x));
        delayCount ++;
        if (Seen > 0 && Mathf.Abs(Target.position.x - transform.position.x) > 0.5f && DmgCounter == 0)
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
        //if it's next to a wall, able to jump over it, grounded, and on a sufficient cooldown
        
        if ( delayCount > 90 && IsAbleToJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);     
            delayCount = 0;
        }
        Flip();
        
    }
    private void FixedUpdate()
    {
        float dist = Vector2.Distance(Target.position, transform.position);
        if (Physics2D.Raycast(transform.position, (Target.position-transform.position), dist, 1<<Ground) || dist > 15f)
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

        
        if (DmgCounter == Mathf.RoundToInt(TimeBetweenAttacks / 2))
        {
            if (Vector2.Distance(transform.position, Target.position) < attackRadius)
            {
                playerHealth.Damage(attackDamage);
                //playerMovement.Knockback((transform.position - Target.position));
                //Debug.Log();
            }
        }
        if (DmgCounter > 0)
        {
            DmgCounter--;
        }

        if (Vector2.Distance(transform.position, Target.position) < attackRadius && DmgCounter == 0 && (isFacingRight == Target.position.x > transform.position.x))
        {
            DmgCounter = TimeBetweenAttacks;
            animator.SetTrigger("Attack");
        }
    }

    private void Flip()
    {
        float horizontalDiff = transform.position.x - Target.position.x;
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
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, wallLayer) && Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer) && ! Physics2D.OverlapCircle(heightCheck.position, 0.2f, wallLayer) && Mathf.Abs(Target.position.x - transform.position.x) > 0.5f;
    }
}
