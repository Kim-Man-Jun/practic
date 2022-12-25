using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public string upAnime = "PlayerUp";
    public string downAnime = "PlayerDown";
    public string rightAnime = "PlayerRight";
    public string leftAnime = "PlayerLeft";
    public string deadAnime = "PlayerDead";

    string nowAnimation = "";
    string oldAnimation = "";

    float axisH;
    float axisV;
    public float angleZ = -90.0f;

    Rigidbody2D rbody;
    bool isMoving = false;

    public static int hp = 3;   //플레이어 hp
    public static string gameState; //게임 상태
    bool inDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        oldAnimation = downAnime;
        gameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
        }

        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);

        if (angleZ >= -45 && angleZ < 45)
        {
            nowAnimation = rightAnime;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            nowAnimation = upAnime;
        }
        else if (angleZ >= -135 && angleZ <= -45)
        {
            nowAnimation = downAnime;
        }
        else
        {
            nowAnimation = leftAnime;
        }

        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }

        if (gameState != "playing" || inDamage)  //게임 중이 아니거나 데미지를 받는 도중에는 아무것도 안함
        {
            return;
        }
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        if (inDamage)   //데미지 받는 상태일때
        {
            float val = Mathf.Sin(Time.time * 50);  //데미지 받을때 점멸시키기
            if (val > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;   //스프라이트 표시
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return; //데미지를 받는 도중에는 조작 불가능 상태 만들기
        }

        rbody.velocity = new Vector2(axisH, axisV) * speed;
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float rad = Mathf.Atan2(dy, dx);
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }
        return angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
        }
    }

    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            hp--;
            if (hp > 0)
            {
                rbody.velocity = new Vector2(0, 0);
                Vector3 toPos = (transform.position - enemy.transform.position).normalized;
                rbody.AddForce(new Vector2(toPos.x * 4, toPos.y * 4), ForceMode2D.Impulse);
                inDamage = true;
                Invoke("DamagedEnd", 0.25f);
            }
            else
            {
                GameOver();
            }
        }
    }

    void DamageEnd()
    {
        inDamage = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    void GameOver()
    {
        gameState = "gameover";
        //여기서부터 게임오버 연출
        GetComponent<CircleCollider2D>().enabled = false;   //플레이어 충돌 판정 비활성
        rbody.velocity = new Vector2(0, 0); //플레이어 이동 중이
        rbody.gravityScale = 1; //플레이어에게 중력을 적용 후에
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse); //중력 적용 후에 위로 튀어오르게 하는 연출
        GetComponent<Animator>().Play(deadAnime);
        Destroy(gameObject, 1.0f);
    }
}
