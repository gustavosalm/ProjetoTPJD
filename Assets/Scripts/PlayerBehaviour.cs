using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float horizontalInput, verticalInput, speed = 5f, forceJump = 5f;
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
        verticalInput = Input.GetAxisRaw("Vertical");
        if (noChao && verticalInput > 0)
        {
            rb.velocity = new Vector2(0, forceJump);
            noChao = false;
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
