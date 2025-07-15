using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Player_move : MonoBehaviour
{
    public float maxSpeed = 3f;
    public float checkDistance = 0.52f;
    public float maxJump = 10f;
    public bool isGrounded = true;
    public bool isFalling = false;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if(move != 0)
        {
            spriteRenderer.flipX = (move == -1);
        }
        animator.SetBool("running", move != 0);

        rb.velocity = new Vector2(maxSpeed * move, rb.velocity.y);

        animator.SetBool("falling", rb.velocity.y < -0.05);

        if(rb.velocity.y <= 0)
        {
            isFalling = true;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, LayerMask.GetMask("Ground"));
        isGrounded = hit.collider != null;
        animator.SetBool("IsGrounded", isGrounded);

        if (isGrounded && isFalling)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isFalling = false;
                rb.AddForce(Vector3.up * maxJump, ForceMode2D.Impulse);
                animator.SetTrigger("jump");
            }
        }
    }
}
