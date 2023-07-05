using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    Animator animator;
    public string IdleAnime = "PlayerIdle";
    public string RunAnime = "PlayerRun";
    public string JumpAnime = "PlayerJump";
    string nowAnime = "";
    string oldAnime = "";

    public float playerDeadAddForce = 0.0f;

    private AudioSource playerjump;
    private AudioSource playerdoublejump;

    //상하좌우로 움직이는 발판 관련 변수
    Vector3 platformPosition;
    Vector3 distance;
    bool PlatformContact;
    GameObject ContactMP;

    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerjump = GetComponent<AudioSource>();
        playerdoublejump = GetComponent<AudioSource>();
        nowAnime = IdleAnime;
        oldAnime = IdleAnime;
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        Moving();

        if (PlatformContact == false)
        {
            if (Input.GetButtonDown("Jump") && jumpCount < 2)
            {
                jumpCount++;
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.AddForce(new Vector2(0, jumpForce));
                playerjump.Play();
            }
            else if (Input.GetButtonDown("Jump") && playerRigidbody.velocity.y > 0)
            {
                playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
                playerdoublejump.Play();
            }
        }
        else if (PlatformContact == true)
        {
            if (Input.GetButtonDown("Jump") && jumpCount < 2)
            {
                PlatformContact = false;
                jumpCount++;
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.AddForce(new Vector2(0, jumpForce));
                playerjump.Play();
            }
            else if (Input.GetButtonDown("Jump") && playerRigidbody.velocity.y > 0)
            {
                PlatformContact = false;
                playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
                playerdoublejump.Play();
            }
        }

        if (PlatformContact == true)
        {
            if (isGround == true && axisH == 0f)
            {
                playerRigidbody.position = ContactMP.transform.position - distance;
            }
        }
    }

    public void Moving()
    {
        if (PlatformContact == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");

            if (axisH > 0.0f)
            {
                transform.localScale = new Vector2(1, 1);
                playerRigidbody.velocity = new Vector2(speed * axisH, playerRigidbody.velocity.y);
            }
            else if (axisH < 0.0f)
            {
                transform.localScale = new Vector2(-1, 1);
                playerRigidbody.velocity = new Vector2(speed * axisH, playerRigidbody.velocity.y);
            }
        }

        else if (PlatformContact == true)
        {
            axisH = Input.GetAxisRaw("Horizontal");

            if (axisH > 0.0f)
            {
                PlatformContact = false;
                transform.localScale = new Vector2(1, 1);
                playerRigidbody.velocity = new Vector2(speed * axisH, playerRigidbody.velocity.y);
            }
            else if (axisH < 0.0f)
            {
                PlatformContact = false;
                transform.localScale = new Vector2(-1, 1);
                playerRigidbody.velocity = new Vector2(speed * axisH, playerRigidbody.velocity.y);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isGround == true)
        {
            if (axisH == 0)
            {
                nowAnime = IdleAnime;
            }
            else
            {
                nowAnime = RunAnime;
            }
        }
        else if (isGround == false)
        {
            nowAnime = JumpAnime;
        }

        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);
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
        GetComponent<BoxCollider2D>().enabled = false;
        playerRigidbody.AddForce(new Vector2(0, playerDeadAddForce), ForceMode2D.Impulse);

        GameManager.instance.OnPlayerDead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y >= 0.8f)
        {
            isGround = true;
            jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("MovingBlock"))
        {
            PlatformContact = true;
            ContactMP = collision.gameObject;
            platformPosition = ContactMP.transform.position;
            distance = platformPosition - transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y >= 1f)
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("MovingBlock"))
        {
            if (PlatformContact == false && axisH == 0.0f)
            {
                PlatformContact = true;
                ContactMP = collision.gameObject;
                platformPosition = ContactMP.transform.position;
                distance = platformPosition - transform.position;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
        PlatformContact = false;
    }
}
