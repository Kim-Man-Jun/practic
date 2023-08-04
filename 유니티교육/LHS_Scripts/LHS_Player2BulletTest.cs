using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_Player2BulletTest : MonoBehaviour
{
    //플레이어 위치에서 길이만큼 발사
    //닿으면 다시 나한테 돌아오기 Raycast Linecast 사용?
    //각도 설정은?

    // 다시 돌아올 타겟
    public Transform target;
    // 이동 속도
    public float speed = 5f;
    // 얘는 왜?
    public float returnSpeedMultiplier = 2f;
    // 돌아옴
    public static bool isReturning = false;
    //간격 위치 저장
    private Vector3 initialPosition;

    private void Start()
    {
        //내 원래 위치 저장
        initialPosition = transform.position;
    }

    private void Update()
    {
        //내 위치에서 랜덤한 방향으로 () 길이만큼 갔다가 다시 온다.
        if (!isReturning)
        {
            // Lerp 또는 Smooth Damp를 사용하여 대상으로 이동
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            //transform.position = Vector3.Lerp(transform.position, target.position, 1);

            // 목표에 도달했는지 확인
            if (transform.position == target.position)
            {
                isReturning = true;
            }
        }

        else
        {
            // 속도를 높여 초기 위치
            float step = speed * returnSpeedMultiplier * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            if (transform.position == initialPosition)
            {
                // 다시 설정
                isReturning = false;
            }
        }
    }
}
