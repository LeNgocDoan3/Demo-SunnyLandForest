using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerStrength; 
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private Animator anim;
    public float jumpForce;

    private enum MovementState {idle, run, fall, jump, climp, hurt,duck}
    
    private float driX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        driX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(driX * playerStrength/2, rb.velocity.y);
       
       if(Input.GetButtonDown("Jump"))
       {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
       } 
        UpdateAnimationUpdate();
       
          
    }
    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if(driX > 0f)
       {
        state = MovementState.run;
        sprite.flipX = false;
       }
       else if(driX < 0f) 
       {
        state = MovementState.run;
        sprite.flipX =true;
       }
       else
       {
        state = MovementState.idle;
       }
       if(rb.velocity.y >1f)
       {
        state = MovementState.jump;
       }
       else if (rb.velocity.y< -.1f)
       {
        state = MovementState.fall;
       }

       anim.SetInteger("state",(int)state);
    }
}
