using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreJump : MonoBehaviour
{
    public GameObject MoreJumpObject;       //MoreJump 게임오브젝트 변수
    public bool MJOnOff;                    //MoreJump 충돌 후 on/off
    public float MJOnOffDeleyTime;          //재생성까지 딜레이

    void Start()
    {
        if (MJOnOff == false)               //충돌 후 MoreJump가 off 됐을 경우
        {
            InvokeRepeating("Respawn", 0.0f, MJOnOffDeleyTime);     //MJOnOffDeleyTime의 텀을 두고 Respawn을 계속 실행
        }
    }

    private void OnTriggerEnter2D(Collider2D other)                 //물체 충돌 판정
    {
        if (other.gameObject.tag == "Player")                       //닿은 대상이 Player일 경우
        {
            if (PlayerController.jumpCount >= 1)                    //PlayerController 스크립트의 jumpCount가 1 이상일 경우
            {
                PlayerController.jumpCount = 1;                       //점프카운트 1로 고정해야지 점프 오류가 안남
                MoreJumpObject.SetActive(false);                    //MoreJump을 비활성화
                MJOnOff = false;                                    //MoreJump 충돌 후 o
            }

            else if (PlayerController.jumpCount == 0)               //PlayerController 스크립트의 jumpCount 0일 경우(점프를 안함)
            {
                MoreJumpObject.SetActive(false);
                MJOnOff = false;
            }
        }
    }

    void Respawn()                                                  //Respawn 함수 
    {
        MoreJumpObject.SetActive(true);
        MJOnOff = true;
    }
}

//https://allaboutmakers.tistory.com/32 게임오브젝트 온오프
//https://novlog.tistory.com/entry/Unity-%EC%BD%94%EB%A3%A8%ED%8B%B4Coroutine-%EC%B4%9D-
//%EC%A0%95%EB%A6%AC-feat-RPG-%ED%8F%AC%EC%85%98-%EB%94%9C%EB%A0%88%EC%9D%B4-%EC%98%88%EC%A0%9C 기본 코루틴 강의
