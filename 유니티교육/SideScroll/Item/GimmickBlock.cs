using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlock : MonoBehaviour
{
    public float Length;        //자동 낙하 탐지 거리
    public bool isDelete = false;
    bool isFell = false;
    float FadeTime;

    // Start is called before the first frame update
    void Start()
    {
        //컴포넌트 가져오기
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //움직임 고정
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if (Player != null)
        {
            float d = Vector2.Distance(transform.position, Player.transform.position);

            if (Length >= d)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();

                if (rb.bodyType == RigidbodyType2D.Static)
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;
                }
            }

        }

        if (isFell) //낙하할 시
        {
            FadeTime -= Time.deltaTime;
            Color col = GetComponent<SpriteRenderer>().color;
            col.a = FadeTime;       //투명도 변경
            GetComponent<SpriteRenderer>().color = col;

            if(FadeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDelete)
        {
            isFell = true;
            Destroy(gameObject, 3f);
        }
    }
}
