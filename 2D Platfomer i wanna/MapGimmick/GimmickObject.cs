using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickObject : MonoBehaviour
{
    public float length = 0.0f;     //자동 낙하 탐지 거리

    void start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;            //물리 현상 고정, inspector에서 static으로 해야함
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
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