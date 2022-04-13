using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    public SpriteRenderer sprite;
    public Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    public float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [Header("Simple AI")]
    //Walk AI
    public float timerStartToWalk = 1f;
    public float timerEndToWalk = 5f;
    private float walking = 0f;
    private bool startWalk = false;
    public float walkForXTime = 1f;
    private float ImWalkingHere = 0f;

    //walk away from player maybe
    public bool runAway = false;
    public float dist2Player = 5f;



    //Jump AI

    //public bool canJump = false;
    public float timerStartToJump = 1f;
    public float timerEndToJump = 5f;
    private float jumpTimer = 0f;
    private bool startJump = false;
    

    //[SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        walking = Random.Range(timerStartToWalk, timerEndToWalk);
        jumpTimer = Random.Range(timerStartToJump, timerEndToJump);

        startWalk = false;
        startJump = false;
        ImWalkingHere = walkForXTime;

    }


    void HorizontalMovement()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        if (dirX > 0 && startWalk)
            rb.AddForce(Vector2.right * moveSpeed);
        else if (dirX < 0 && startWalk)
            rb.AddForce(Vector2.left * moveSpeed);
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    void walkingLogic()
    {
        if (walking <= 0)
        {
            if (startWalk == false)
            {
                int pickDirection = Random.Range(0, 2);
                if (pickDirection == 0)
                    dirX = -1f;
                else
                    dirX = 1f;
            }
            startWalk = true;
            if (ImWalkingHere <= 0)
            {
                //startWalk = false;
                ImWalkingHere = walkForXTime;
                startWalk = false;
                walking = Random.Range(timerStartToWalk, timerEndToWalk);
            }
            else
                ImWalkingHere -= Time.deltaTime;
        }
        else
        {
            walking -= Time.deltaTime;
        }
    }

    void jumpingLogic()
    {
        if (jumpTimer <= 0 && startJump == false)
        {
            startJump = true;
            jumpTimer = Random.Range(timerStartToJump, timerEndToJump);

        }
        else
        {
            jumpTimer -= Time.deltaTime;
        }

        if (startJump && IsGrounded())
        {
            startJump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
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
        walkingLogic();
        jumpingLogic();
        updateAnimValues();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
