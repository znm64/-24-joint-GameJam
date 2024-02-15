using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Input.GetKey("a") && Input.GetKey("d")))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal*speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        bool g = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Debug.Log(g.ToString());
        return g;
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
