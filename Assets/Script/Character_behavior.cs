using UnityEngine;

public class Character_behavior : MonoBehaviour
{

    //--VARIABLE--//
    public Rigidbody2D rb;
    public float speed;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask colllisionLayers;

    public Animator animator;

    public SpriteRenderer sprite;

    //--SAUT--//

    bool isJumping;
    public bool isGrounded;
    private float horizontalMovement;

    //--VECTOR--//
    private Vector3 velocity = Vector3.zero;

    void start()
    {

    }
    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (!isGrounded) animator.SetBool("jumping", true);
        else animator.SetBool("jumping", false);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            animator.SetBool("jumping", isJumping);
        }

        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        float CharacterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", CharacterVelocity);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, colllisionLayers);

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            animator.SetBool("jumping", isJumping);
            rb.AddForce(Vector2.up * jumpSpeed);
            isJumping = false;

        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f) sprite.flipX = false;
        if (_velocity < -0.1f) sprite.flipX = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("grounded", isGrounded);
            animator.SetBool("jumping", false);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("grounded", isGrounded);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }
}