using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float axisH = 0.0f;                         //움직임 관련 변수
    public float speed = 5.0f;

    public float jumpForce = 700f;              //점프력
    public static int jumpCount = 0;            //점프횟수

    private bool isGround = false;              //캐릭터가 땅을 밟는지 안 밟는지
    public bool isDead = false;                 //캐릭터가 죽은지 판단

    Rigidbody2D playerRigidbody;

    Animator animator;                          //플레이어 애니메이션 관련 변수
    public string IdleAnime = "PlayerIdle";
    public string RunAnime = "PlayerRun";
    public string JumpAnime = "PlayerJump";
    string nowAnime = "";
    string oldAnime = "";

    public float playerDeadAddForce = 0.0f;     //캐릭터 죽었을 때 튀어오르는 정도

    private AudioSource playerjump;             //캐릭터 소리 관련 변수
    private AudioSource playerdoublejump;

    //상하좌우로 움직이는 발판 관련 변수
    Vector3 platformPosition;
    Vector3 distance;
    bool PlatformContact;
    GameObject ContactMP;

    //싱글톤 선언용
    static PlayerController Instance;

    private void Awake()                        //싱글톤 선언과 동시에 플레이어 한개로 고정
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()                                //component 가져오는 동시에 애니메이션도 초기화
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
        if (isDead)                             //캐릭터가 죽었을 때 아무것도 안함
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
            else if (Input.GetButtonDown("Jump") && playerRigidbody.velocity.y > 0 && jumpCount == 1)
            {
                playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
                playerdoublejump.Play();
            }
        }
        else if (PlatformContact == true)
        {
            if (Input.GetButtonDown("Jump") && jumpCount < 1)
            {
                PlatformContact = false;
                jumpCount++;
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.AddForce(new Vector2(0, jumpForce));
                playerjump.Play();
            }
            if (Input.GetButtonDown("Jump") && playerRigidbody.velocity.y > 0 & jumpCount == 1)
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
            isDead = true;
            Die();
        }
    }

    public void Die()
    {
        if (isDead == true)
        {
            nowAnime = JumpAnime;
            animator.Play(nowAnime);
            playerRigidbody.velocity = Vector2.zero;
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            playerRigidbody.AddForce(new Vector2(0, playerDeadAddForce), ForceMode2D.Impulse);

            GameManager.instance.OnPlayerDead();
        }
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
