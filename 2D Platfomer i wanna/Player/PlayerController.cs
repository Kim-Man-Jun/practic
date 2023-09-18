using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Info")]
    float axisH = 0.0f;                         //움직임 관련 변수
    public float speed = 5.0f;

    [Header("Jump Info")]
    public float jumpForce = 700f;              //점프력
    public static int jumpCount = 0;            //점프횟수
    public float playerDeadAddForce = 0.0f;     //캐릭터 죽었을 때 튀어오르는 정도

    [Header("ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;

    [Header("treadable Check")]
    [SerializeField] private Transform treadableCheck;
    [SerializeField] private float treadableDistance;
    [SerializeField] private LayerMask treadableLayer;

    public bool isDead = false;                 //캐릭터가 죽은지 판단

    string nowAnima;
    string oldAnima;

    //component 가져오기
    Rigidbody2D rb;
    Animator anima;
    SpriteRenderer sr;

    //캐릭터 소리 관련 변수
    private AudioSource sd;
    public AudioClip playerjump;
    public AudioClip playerdoublejump;

    //싱글톤 선언용
    static PlayerController Instance;

    //현재 플레이어가 있는 방 번호
    public int PlayerNowRoom = 0;

    public float secondJump;

    //싱글톤 선언과 동시에 플레이어 한개로 고정
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sd = GetComponent<AudioSource>();

        nowAnima = "Idle";
        oldAnima = "Idle";
    }

    private void Update()
    {
        //죽었을 경우 update 실행 안함
        if (isDead) return;

        PlayerMovement();
        AnimationController();
    }

    //Player 전체적인 움직임 관련 메서드
    public void PlayerMovement()
    {
        //움직임 변수
        axisH = Input.GetAxisRaw("Horizontal");

        //좌우로 움직일때
        if (axisH != 0)
        {
            if (axisH > 0.0f)
            {
                transform.localScale = new Vector2(1, 1);
                rb.velocity = new Vector2(speed * axisH, rb.velocity.y);
            }
            else if (axisH < 0.0f)
            {
                transform.localScale = new Vector2(-1, 1);
                rb.velocity = new Vector2(speed * axisH, rb.velocity.y);
            }
        }

        //점프할때
        if (Input.GetKeyDown(KeyCode.X))
        {
            //기본 점프
            if (jumpCount == 0 && (isGroundDetected() == true || istreadableDetected() == true))
            {
                //애니메이션이나 가속도 조절하기 위해 Vector2.zero 사용
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, jumpForce));
                sd.PlayOneShot(playerjump);
            }
            //이단 점프
            else if (jumpCount == 1)
            {
                rb.velocity = Vector2.zero;
                sd.PlayOneShot(playerdoublejump);
                rb.velocity = new Vector2(0, jumpForce * secondJump);
                jumpCount = 0;
            }
            //jumpcount 2는 morejump 먹었을 때만 사용함
            else if (jumpCount == 2)
            {
                rb.velocity = Vector2.zero;
                sd.PlayOneShot(playerdoublejump);
                rb.velocity = new Vector2(0, jumpForce * secondJump);
                jumpCount = 0;
            }
        }
    }

    //Player Animation 관련 메서드
    public void AnimationController()
    {
        //Idle, Run 관련
        if (isGroundDetected() || istreadableDetected())
        {
            if (axisH == 0)
            {
                nowAnima = "Idle";
            }

            else if (axisH != 0)
            {
                nowAnima = "Run";
            }
        }

        //점프 상태나 이단 점프 상태일때 애니메이션 처리
        else if (isGroundDetected() == false || istreadableDetected() == false)
        {
            nowAnima = "Jump";
            anima.SetFloat("yVelocity", rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.X))
            {
                nowAnima = "DoubleJump";
                anima.SetFloat("DouyVelocity", rb.velocity.y);
            }
        }

        //Animation 교체
        if (nowAnima != oldAnima)
        {
            anima.SetBool(oldAnima, false);
            oldAnima = nowAnima;
            anima.SetBool(nowAnima, true);
        }
    }

    //Player가 가시나 총알 등에 맞아 죽었을 때
    public void Die()
    {
        if (isDead == true)
        {
            //죽는 animation 설정
            nowAnima = "Jump";
            anima.SetBool(nowAnima, true);

            //움직임 멈추기
            rb.velocity = Vector2.zero;
            //모든 물체 관통하기
            GetComponent<CapsuleCollider2D>().enabled = false;

            rb.AddForce(new Vector2(0, playerDeadAddForce), ForceMode2D.Impulse);

            GameManager.instance.OnPlayerDead();
        }
    }

    //플레이어 사망 판정
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Dead" || other.tag == "Boss") && !isDead)
        {
            isDead = true;
            Die();
        }
    }

    //Player가 발판 등에서 잠깐 떨어질 때 바로 이단 점프 못하도록 막음
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Treadable")
        {
            jumpCount = 1;
        }
    }

    //Ground bool값 반환
    public bool isGroundDetected() => Physics2D.Raycast(groundCheck.position,
        Vector2.down, groundDistance, groundLayer);
    public bool istreadableDetected() => Physics2D.Raycast(treadableCheck.position,
        Vector2.down, treadableDistance, treadableLayer);

    //editor 모드에서 보기 편하게 gizmos 사용
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x,
            groundCheck.position.y - groundDistance));
        Gizmos.color = Color.red;

        Gizmos.DrawLine(treadableCheck.position, new Vector3(treadableCheck.position.x,
            treadableCheck.position.y - treadableDistance));
        Gizmos.color = Color.yellow;
    }
}
