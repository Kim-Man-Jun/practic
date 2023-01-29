using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;          // Rigidbody2D 형의 변수
    float axisH = 0.0f;
    public float speed = 3.0f;  // 이동속도

    public float jump = 9.0f;       // 점프력
    public LayerMask groundLayer;   // 착지할 수 있는 레이어
    bool goJump = false;            // 점프 개시 플래그
    bool onGround = false;          // 지면에 서있는 플래그

    Animator animator;
    public string idleAnime = "PlayerIdle";
    public string jumpAnime = "PlayerJump";
    public string runAnime = "PlayerRun";
    string nowAnime = "";
    string oldAnime = "";


    void Start()
    {
        // Rigidbody2D 가져오기
        rbody = this.GetComponent<Rigidbody2D>();
        // Animator 가져오기
        animator = GetComponent<Animator>();
        nowAnime = idleAnime;
        oldAnime = idleAnime;
    }

    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");

        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump(); // 점프
        }
    }

    void FixedUpdate()
    {
        onGround = Physics2D.Linecast(transform.position,
                                      transform.position - (transform.up * 0.1f),
                                      groundLayer);

        if (onGround || axisH != 0)  //지면 위 또는 속도가 0이 아닐때
        {
            rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
        }

        if (onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }

        if (onGround)
        {
            if (axisH == 0)
            {
                nowAnime = idleAnime;
            }
            else
            {
                nowAnime = runAnime;
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

    public void Jump()
    {
        goJump = true;
        Debug.Log("점프 버튼 누름");
    }


}
