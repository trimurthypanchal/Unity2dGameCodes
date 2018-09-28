using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {
                                                                 // double/tiple/... jumpcontroller

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight=true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisground;

    private int extrajump;
    public int extrajumpvalue;

	void Start () {

        extrajump = extrajumpvalue;
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if (isGrounded == true)
        {
            extrajump = 2;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extrajump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extrajump--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extrajumpvalue == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

        }
    }

	void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisground);     //groundcheck

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed,rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
	}


    void Flip()
    {
        facingRight = !facingRight;                //if ture become false..vice versa
        Vector3 Scaler = transform.localScale;     //set the scalar veriable equal  to the local scale of player ie player x,y,z scale values
        Scaler.x *= -1;                            //set scalar x value to negative
                                                    //when this code runs if player scaleis 2 then it becomes -2
        transform.localScale = Scaler;
    }
}
