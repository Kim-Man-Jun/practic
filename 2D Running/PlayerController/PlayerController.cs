using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float axisH = 0.0f;
    public float speed = 5.0f;

    public float jumpForce = 700f;
    public static int jumpCount = 0;

    private bool isGround = false;
    private bool isDead = false;

    Rigidbody2D playerRigidbody;

    public float playerDeadAddForce = 0.0f;

    private AudioSource playerjump;
    private AudioSource playerdoublejump;
    
    bool isBulletTime;

    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        playerjump = GetComponent<AudioSource>();
        playerdoublejump = GetComponent<AudioSource>();
        isBulletTime = false;
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }
        else if (Input.GetMouseButtonDown(0) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        
        if(Input.GetMouseButton(1) && isBulletTime = false)
        {
            Time.timeScale = 0.5f;
            isBulletTime = true;
        }
        
        if(Input.GetMouseButtonUp(1) && isBulletTime = true)
        {
            Time.timeScale = 1.0f;
            isBulletTime = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        playerRigidbody.velocity = Vector2.zero;
        GetComponent<CapsuleCollider2D>().enabled = false;
        playerRigidbody.AddForce(new Vector2(0, playerDeadAddForce), ForceMode2D.Impulse);

        GameManager.instance.OnPlayerDead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.2f)
        {
            isGround = true;
            jumpCount = 0;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
    
}
