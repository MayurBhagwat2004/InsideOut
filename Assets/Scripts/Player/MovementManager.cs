using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    [SerializeField]internal bool backButtonPressed;
    [SerializeField]internal bool forwardButtonPressed;
    [SerializeField] internal bool jumpButtonPressed;

    [SerializeField]private float speed;
    [SerializeField]public float jump;

    private bool onGround;
    private Trampoline trampolineInstance;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private SpriteRenderer spriteRenderer;

    internal static MovementManager instance;

    private void Start()
    {
        trampolineInstance = FindAnyObjectByType<Trampoline>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = 10f;
        jump = 20f;
        instance = this;
    }

    private void Update()
    {
        Movement();
    }


    private void Movement() 
    {
        if (forwardButtonPressed) 
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            spriteRenderer.flipX = false;
        }
        if (backButtonPressed) 
        {
            rb.velocity = new Vector2 (-speed, rb.velocity.y);
            spriteRenderer.flipX = true;
        }
        if (jumpButtonPressed && onGround) 
        {
            rb.velocity = new Vector2 (rb.velocity.x, jump);
        }
        if (trampolineInstance.playerOnTheTramp) 
        {
            rb.velocity = new Vector2(rb.velocity.x,jump+12);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground") 
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
