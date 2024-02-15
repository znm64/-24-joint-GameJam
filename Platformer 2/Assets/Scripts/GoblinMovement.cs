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
    
    private float horizontal;
    private float speed = 1f;
    private bool isFacingRight;
    private int Seen = 0;

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
        
    }
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(rb.gameObject.transform.position, (Target.position - rb.gameObject.transform.position), 1000f, 1<<Ground) || (Target.position - rb.gameObject.transform.position).magnitude > 1000f)
        {
            if (Seen > 0)
            {
                Seen--;
            }
        }
        else
        {
            Seen = 10;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
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
}
