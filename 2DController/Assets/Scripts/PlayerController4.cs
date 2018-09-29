using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{

    public float speed;                                   //hallowknight like jump
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

   

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisground;

    private float jumpTimerCounter;
    public float jumpTime;
    public bool isJumping;
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisground);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimerCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {

            if (jumpTimerCounter > 0)
            {

                rb.velocity = Vector2.up * jumpForce;
                jumpTimerCounter -= Time.deltaTime;
            }
        }
        else
        {
            isJumping = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

    }
}