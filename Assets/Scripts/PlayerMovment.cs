using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private CoinCounter coinCounter;
    public TextMeshProUGUI coinText;
    public static int coinCount = 0;

    public float speed;
    public float turboSpeed;
    public float currentSpeed;
    //
    private float dashDuration = 0.5f; // Duration of the dash in seconds
    private float dashTimer = 0; // Timer to track the dash duration
    private bool isDashing = false; // To check if the player is currently dashing
    
    private bool canDash = true; // To check if the player can dash
    public float dashCooldownTime = 0.5f; // Cooldown period in seconds after dashing
    private float dashCooldownTimer; // Timer to track the cooldown
   
    private int jumpCount = 0;
    private int maxJumpCount = 3; // Including the ground jump
    //

    public Rigidbody2D rb;
    public float jumpForce = 5f;
    private bool isGrounded = true;

    //

    public AudioClip clip;
    AudioSource audioSource;


    void Start()
    {
        coinCounter = FindObjectOfType<CoinCounter>(); // Find the CoinCounter component in the scene
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isDashing && canDash)
        {
            isDashing = true;
            dashTimer = dashDuration;
            canDash = false; // Prevent further dashes until cooldown is over
            currentSpeed = turboSpeed; // Apply turbo speed
        }
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                isDashing = false;
                dashCooldownTimer = dashCooldownTime; // Start cooldown timer
                currentSpeed = speed;
            }
        }
        if (!canDash)
        {
            dashCooldownTimer -= Time.deltaTime;
            if (dashCooldownTimer <= 0)
            {
                canDash = true; // Player can dash again
            }
        }
        // JUMPING LOGIC
        float xMove = Input.GetAxisRaw("Horizontal");
        transform.Translate(xMove * currentSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded || jumpCount < maxJumpCount) // if isGrounded = T or jumped < 2 times
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
                isGrounded = false; // Will be reset to true when the player touches the ground again
            }
            else if (!isGrounded && canDash)
            {
                // Dashing logic
                canDash = false;
                dashCooldownTimer = dashCooldownTime; // Reset cooldown timer
                // Apply dash force or change speed here

            }
        }


    }


    //destroyes the coin when triggered and not collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCounter.IncrementCoinCount();
            Destroy(other.gameObject); // Destroy the coin
            audioSource.PlayOneShot(clip);
        }
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset jump count
            canDash = true; // Allow dashing again
        }
        if (other.gameObject.CompareTag("Hazard"))
        {
            Destroy(gameObject); // destroy platyer 
        }

    }

    //trigger to detect if the player is touching the ground
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}