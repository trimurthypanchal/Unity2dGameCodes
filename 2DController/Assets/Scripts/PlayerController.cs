using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;                                   //top down contrroller
    public Rigidbody2D rb;
    private Vector2 moveVelocity;

	
	void Start () {

        rb = GetComponent<Rigidbody2D>();
		
	}
	
	
	void Update () {

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));        //smooth movement

        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));   //for snappy movement

        moveVelocity = moveInput.normalized * speed;
		
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
