
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    private int jumps = 2;
    private Vector2 knockback = Vector2.zero;
    private float attackRadius = 0.5f;
    private int attackDamage = 1;
    private int TimeBetweenAttacks = 40;
    private int DmgCounter = 0;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;
    
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

        if (Input.GetKeyDown(KeyCode.Space) && DmgCounter == 0)
        {
            DmgCounter = TimeBetweenAttacks;
            animator.SetTrigger("Attack");
        }

        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y) + knockback;
        //knockback *= 99 / 100;
        //Debug.Log(knockback);
        if (DmgCounter == Mathf.RoundToInt(TimeBetweenAttacks / 2))
        {
            Attack();
        }
        if (DmgCounter > 0)
        {
            DmgCounter--;
        }
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

    public void Knockback(Vector2 amount)
    {
        knockback = amount;
    }

    private void Attack()
    {
        Collider2D[] Enemies = Physics2D.OverlapCircleAll(attackCheck.position, attackRadius, enemyLayer);
        foreach (Collider2D enemy in Enemies)
        {
            enemy.GetComponent<EnemyHealth>().Damage(attackDamage);
        }
        
    }
}
