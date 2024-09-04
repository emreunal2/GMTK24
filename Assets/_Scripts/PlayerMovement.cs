using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] bool isFacingRight = false;
    [SerializeField]float horizontalMovement, verticalMovement;
    [SerializeField]float moveSpeed;
    [SerializeField]float jumpForce;
    [SerializeField]LayerMask groundLayer;
    
    private bool isOnGround;
    [SerializeField] GameObject groundCheck;

    private float moveInput;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, 0.2f, groundLayer);
        if (moveInput != 0)
        {
            TurnCheck();
        }
    }

    private void TurnCheck()
    {
        if (moveInput > 0 && !isFacingRight)
        {
            Turn();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        if (isFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = false;
        }
        else 
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = true;
        }
    }
}
 
