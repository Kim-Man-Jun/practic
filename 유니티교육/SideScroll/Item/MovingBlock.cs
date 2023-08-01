using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float moveX = 0.0f;
    public float moveY = 0.0f;
    public float times = 0.0f;
    //정지시간
    public float weight = 0.0f;

    //올라갔을때 움직이기
    public bool isMoveWhenOn = false;
    //움직임
    public bool isCanMove = true;
    //프레임당 x 이동값
    float perDX;
    float perDY;

    //초기 위치
    Vector3 defPos;
    //반전여부
    bool isReverse = false;

    // Start is called before the first frame update
    void Start()
    {
        //초기 위치
        defPos = transform.position;
        //1프레임에 이동하는 시간
        float timestep = Time.fixedDeltaTime;
        //1프레임의 X 이동값
        perDX = moveX / (1.0f / timestep * times);
        perDY = moveY / (1.0f / timestep * times);

        if (isMoveWhenOn)
        {
            //처음에는 움직이지 않고 올라가면 시작
            isCanMove = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCanMove)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            bool endX = false;
            bool endY = false;
            if (isReverse)
            {
                //반대방향 이동
                //이동량이 양수고 이동 위치가 초기 위치보다 작거나
                //이동량이 음수고 이동 위치가 초기 위치보다 큰 경우
                if ((perDX >= 0.0f && x <= defPos.x)
                    || (perDX < 0.0f && x >= defPos.x))
                {
                    endX = true;
                }

                if ((perDY >= 0.0f && y <= defPos.y)
                    || (perDY < 0.0f && y >= defPos.y))
                {
                    endY = true;
                }
                //블럭 이동
                transform.Translate(new Vector3(-perDX, -perDY, defPos.z));
            }
            else
            {
                //정방향이동
                //이동량이 양수고 이동 위치가 초기 위치보다 크거나
                //이동량이 음수고 위동 위치가 초기 위치보다 작은 경우
                if ((perDX >= 0.0f && x >= defPos.x + moveX)
                    || (perDX < 0.0f && x < defPos.x + moveX))
                {
                    endX = true;
                }

                if ((perDY >= 0.0f && y >= defPos.y + moveY)
                    || (perDY < 0.0f && y < defPos.y + moveY))
                {
                    endY = true;
                }

                Vector3 v = new Vector3(perDX, perDY, defPos.z);
                transform.Translate(v);
            }
            if (endX && endY)
            {
                if (isReverse)
                {
                    //위치가 어긋나는 것을 방지하고자 정면 방향 이동으로
                    //돌아가기 전에 초기 위치로 돌리기
                    transform.position = defPos;
                }
                isReverse = !isReverse;
                isCanMove = false;
                if (isMoveWhenOn == false)
                {
                    //올라갔을 때 움직이는 값이 꺼진 경우
                    Invoke("Move", weight);
                }
            }
        }
    }

    public void Move()
    {
        isCanMove = true;
    }

    public void Stop()
    {
        isCanMove = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
            if (isMoveWhenOn)
            {
                isCanMove = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
