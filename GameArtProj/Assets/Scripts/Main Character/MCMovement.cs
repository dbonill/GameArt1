using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    public SpriteRenderer sprite;
    public Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    //[SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (dirX > 0)
            rb.AddForce(Vector2.right * moveSpeed);
        else if (dirX < 0)
            rb.AddForce(Vector2.left * moveSpeed);
        //rb.AddForce(new Vector2(dirX * moveSpeed, rb.velocity.y));
        //rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //jumpSoundEffect.Play();
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }

        //UpdateAnimationState();
    }

    /*
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    */

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
