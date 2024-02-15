
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    private int jumps = 2;

    [SerializeField] private Animator animator;
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
        bool grounded = IsGrounded();
        if (grounded)
        {
            jumps = 2;
        }
        else if (jumps == 2)
        {
            jumps = 1;
        }
        if (!(Input.GetKey("a") && Input.GetKey("d")))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetKeyDown("w") && jumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumps--;
        }

        animator.SetBool("IsRunning", (horizontal != 0f));
        animator.SetBool("IsGrounded", grounded);
        animator.SetBool("IsJumping", (rb.velocity.y > 0.1f));
        animator.SetBool("IsFalling", (rb.velocity.y < -0.1f));

        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal *speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
