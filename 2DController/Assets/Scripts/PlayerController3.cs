using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    // detailed player controller with partical effect

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private Animator anim;

    

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisground;

    private bool spawndust;
    public GameObject dustEffect;

    private float timebtwTrail;
    public float startTimeBtwTrail;

    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator> ();

    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisground);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0f, 0);

        }

        if (moveInput != 0 && isGrounded == true)
        {
            anim.SetBool("isRunning", true);
        }
        else if (moveInput == 0 && isGrounded == false)
        {
            anim.SetBool("isRunning", false);
        }
    }

    void Update()
    {

        if (isGrounded == true)
        {
            if (spawndust == true)
            {

                Instantiate(dustEffect, groundCheck.position, Quaternion.identity);
                spawndust = false;
            }
        }
        else
        {
            spawndust = true;
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            Instantiate(dustEffect, groundCheck.position, Quaternion.identity);
            anim.SetTrigger("jump");
        }

        //Trail when character moveInput
        if (moveInput != 0)
        {
            if (timebtwTrail <= 0)
            {
                Instantiate(dustEffect, groundCheck.position, Quaternion.identity);
                timebtwTrail = startTimeBtwTrail;
            }
        }
        else
        {
            timebtwTrail -= Time.deltaTime;
        }

    }
}


        