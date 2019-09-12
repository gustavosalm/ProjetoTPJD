using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float horizontalInput, verticalInput, speed = 3f, forceJump = 15f;
    private bool noChao;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private Joystick joystick;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        noChao = true;
    }
    void FixedUpdate(){
        Move();
        Jump();
    }

    private void Jump()
    {
        noChao = Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.6f), 0.5f, LayerMask.GetMask("Chao"));
        verticalInput = joystick.Vertical;
        if (noChao && verticalInput >= 0.5f)
        {
            anim.SetBool("jump", true);
            rb.velocity = new Vector2(0, forceJump);
        }
        else
        {
            anim.SetBool("jump", false);
        }

    }

    private void Move()
    {
        horizontalInput = joystick.Horizontal * speed;

        anim.speed = (Mathf.Abs(horizontalInput) >= 0.3f)? (Mathf.Abs(horizontalInput) >= 1.5f)? 1.5f : Mathf.Abs(horizontalInput) : (anim.GetBool("walk") == false)? 1f : 0f ;

        if (horizontalInput >= 0.6f)
        {
            sr.flipX = false;
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime);
            anim.SetBool("walk", true);
        }
        else if (horizontalInput <= -0.6f)
        {
            sr.flipX = true;
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime);
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        //horizontalInput = (joystick.Horizontal >= 0.2f) ? speed : (joystick.Horizontal <= -0.2f) ? -speed : 0f;
        //verticalInput = (joystick.Vertical >= 0.2f) ? speed : (joystick.Vertical <= -0.2f) ? -speed : 0f;
    }
}
