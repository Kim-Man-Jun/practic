using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float axisH = 0.0f;
    public float speed = 5.0f;

    public float jumpForce = 700f;
    public int jumpCount = 0;

    private bool isGround = false;
    private bool isDead = false;

    Rigidbody2D playerRigidbody;

    Animator animator;
    public string IdleAnime = "PlayerIdle";
    public string RunAnime = "PlayerRun";
    public string JumpAnime = "PlayerJump";
    string nowAnime = "";
    string oldAnime = "";
    
    float Time = 0.0f;
    public float FadeTime = 0.0f;
    
    private AudioSource playerjump;
    private AudioSource playerdoublejump;

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

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }
        
        if (isGround)
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
        else
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
        
        if(other.gameObject.tag == "Clear")
        {
            GameManager.ClearGame();
        }
    }

    public void Die()
    {
        isDead = true;
        playerRigidbody.velocity = Vector2.zero;
        GetComponent<CapsuleCollider2D>().enabled = false;
        
        if(FadeTime < Time)
        {
            GetComponent<SpriteRenderer>().color = new Coloer(1, 1, 1, 1f - FadeTime/Time);
        }
        else
        {
            FadeTime = 0.0f;
            this.gameObject.SetActive(false);
        }
        FadeTime += Time.deltaTime;
        
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

//중간에 있는 애니메이션 메서드 제거한 후에 애니메이터를 이용한 캐릭터 애니메이션 구현 예정
