using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;

     [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed =7f;
    [SerializeField] private float jumpForce =15f;

    private enum Movementstate { idle,run,jump,fall }
    public AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        Movementstate state;

        if(dirX > 0f)
        {
            state = Movementstate.run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = Movementstate.run;
            sprite.flipX = true;
        }
        else
        {
            state = Movementstate.idle;
        }


        if(rb.velocity.y >.1f)
        {
            state = Movementstate.jump;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = Movementstate.fall;
        }

        anim.SetInteger("state",(int)state);
    }

    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
