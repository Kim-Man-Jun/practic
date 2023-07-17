using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    bool leftFlag = false;
    Rigidbody2D rbody;
    Animator playerani;
    public float JumpPower = 5f;
    public float MaxSpeed = 5.0f;
    float vx;

    SpriteRenderer spriteRender;

    private bool isJump;

    public bool KeyOnOff = false;
    // Start is called before the first frame update
    void Start()
    {
        //중력을 0으로 해서 충돌 시 회전시키지 않는다.
        rbody = GetComponent<Rigidbody2D>();
        playerani = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            leftFlag = false;
            playerani.SetBool("Move", true);
        }
        else if (h < 0)
        {
            leftFlag = true;
            playerani.SetBool("Move", true);
        }
        else
        {
            playerani.SetBool("Move", false);
        }

        spriteRender.flipX = leftFlag;

        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJump)
            {
                isJump = true;
                rbody.AddForce(Vector3.up * JumpPower, ForceMode2D.Impulse);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //rbody.velocity = new Vector2(vx, rbody.velocity.y);

        rbody.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (rbody.velocity.x > MaxSpeed)
        {
            rbody.velocity = new Vector2(MaxSpeed, rbody.velocity.y);
        }
        else if (rbody.velocity.x < MaxSpeed * (-1))
        {
            rbody.velocity = new Vector2(MaxSpeed * (-1), rbody.velocity.y);
        }

        //if (Input.GetKey("right"))
        //{
        //    vx = speed;
        //    leftFlag = false;
        //    playerani.SetBool("Move", true);
        //}
        //else if (Input.GetKey("left"))
        //{
        //    vx = -speed;
        //    leftFlag = true;
        //    playerani.SetBool("Move", true);
        //}
        //else
        //{
        //    //안 움직일때
        //    playerani.SetBool("Move", false);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            KeyOnOff = true;
            Debug.Log(KeyOnOff);
        }
    }
}
