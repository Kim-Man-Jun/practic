using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GimmickObject : MonoBehaviour
{
    public float length = 0.0f;     //자동 낙하 탐지 거리
    public Vector2 PlayerVector;    //플레이어의 벡터2 값
    public Vector2 myselfVector;    //현재 오브젝트의 벡터2 값

    void Start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;            //물리 현상 고정, inspector에서 static으로 해야함
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");     //플레이어 변수를 만들고 오브젝트 찾기
        PlayerVector = player.GetComponent<Transform>().position;       //플레이어 위치값 구하기           
        myselfVector = GetComponent<Transform>().position;              //현재 오브젝트의 위치값 구하기

        if (player != null)         //플레이어가 있을 경우
        {
            float Angle = GetAngle(PlayerVector, myselfVector);         //현재 오브젝트에서 플레이어의 위치 각도 산출

            if (Angle >= 60 && Angle <= 120)            //각도가 60도 이상, 120도 이하일 때 밑 함수 실행
            {
                float d = Vector2.Distance(transform.position, player.transform.position);      //플레이어와의 거리 계산

                if (length >= d)         //위 계산한 거리가 탐지 거리보다 작거나 같을 경우에
                {
                    Rigidbody2D rbody = GetComponent<Rigidbody2D>();

                    if (rbody.bodyType == RigidbodyType2D.Static)
                    {
                        rbody.bodyType = RigidbodyType2D.Dynamic;     //물리 현상 고정 해제

                        Destroy(this.gameObject, 2.5f);
                    }
                }
            }
        }
    }

    //새로운 메서드 생성, 괄호 안에 위처럼 변수들을 넣으면 그 값들이 vstart와 vend가 된다
    public static float GetAngle(Vector2 vStart, Vector2 vEnd)      
    {
        Vector2 v = vEnd - vStart;          //변수 v 생성 
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;       //이거는 알아봐야함
    }
}
