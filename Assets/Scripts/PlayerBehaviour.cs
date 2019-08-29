using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float horizontalInput, verticalInput, speed = 5f, forceJump = 10f;
    private bool noChao;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
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
        verticalInput = Input.GetAxisRaw("Vertical");
        if (noChao && verticalInput > 0)
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
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0)
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            sr.flipX = false;
            anim.SetBool("walk", true);
        }
        else if (horizontalInput < 0)
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            sr.flipX = true;
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }
}
