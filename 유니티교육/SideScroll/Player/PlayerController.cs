using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    SpriteRenderer sp;

    //이동 관련 변수들
    public float Speed = 2f;
    float axisH = 0f;

    //점프 관련 변수들
    public float JumpPower = 3f;        //점프력
    public LayerMask groundLayer;       //착지할 수 있는 레이어 변수
    bool goJump = false;                //점프 on/off
    bool onGround = false;              //지면착지 on/off

    //애니메이터
    Animator animator;

    public string stopAnime = "Idle";
    public string moveAnime = "Move";
    public string jumpAnime = "Jump";
    public string goalAnime = "Clear";
    public string deadAnime = "Dead";
    string nowAnime = "";
    string oldAnime = "";

    public static string gameState = "playing";

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }

        axisH = Input.GetAxisRaw("Horizontal");
        /*
        if (axisH < 0)
        {
            sp.flipX = true;
        }
        else if (axisH > 0)
        {
            sp.flipX = false;
        }
        */

        if (axisH < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (axisH > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            Jump(); //점프키
        }
    }

    private void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }

        //착지판정
        onGround = Physics2D.Linecast(transform.position, transform.position
            - (transform.up * 1.5f), groundLayer);

        if (onGround || axisH != 0f)
        {
            rbody.velocity = new Vector2(Speed * axisH, rbody.velocity.y);
        }

        if (onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, JumpPower);     //점프 벡터
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);    //순간적인 힘 가하기
            goJump = false;
        }

        if (onGround)
        {
            if (axisH == 0)
            {
                nowAnime = stopAnime;
            }
            else
            {
                nowAnime = moveAnime;
            }
        }
        else
        {
            nowAnime = jumpAnime;
        }

        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }

        if (collision.gameObject.tag == "Dead")
        {
            GameOver();
            gameState = "gameOver";
        }
    }

    public void Jump()
    {
        goJump = true;
    }

    public void Goal()
    {
        animator.Play(goalAnime);
        gameState = "gameClear";
        GameStop();
    }

    public void GameOver()
    {
        animator.Play(deadAnime);
        gameState = "gameOver";

        CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
        capsule.enabled = false;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    void GameStop()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();

        rbody.velocity = new Vector2(0, 0);
    }
}
