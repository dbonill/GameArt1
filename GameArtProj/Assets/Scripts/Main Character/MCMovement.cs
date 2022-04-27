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

    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void HorizontalMovement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if(dirX == -1)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if(dirX == 1)
            transform.localScale = new Vector3(1f, 1f, 1f);

        anim.SetFloat("speed", Mathf.Abs(dirX));
        if (dirX > 0)
            rb.AddForce(Vector2.right * moveSpeed);
        else if (dirX < 0)
            rb.AddForce(Vector2.left * moveSpeed);
    }

    private void FixedUpdate()
    {
        if(!GameCommands.ControlEnemy)
            HorizontalMovement();
        else
            anim.SetFloat("speed", Mathf.Abs(0));
    }

    void updateAnimValues()
    {
        anim.SetBool("grounded", IsGrounded());
        if (rb.velocity.y > 0 && !IsGrounded())
        {
            anim.SetBool("Jumping", true);
            anim.SetBool("Falling", false);
        }
        else if (rb.velocity.y < 0 && !IsGrounded())
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(rb.velocity.y + " CURRENT Y VELOCITY MAIN CHARACTER");
        if (Input.GetButtonDown("Jump") && IsGrounded() && !GameCommands.ControlEnemy)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        updateAnimValues();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
