using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float speed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = player.transform.position - transform.position;       //목표 오브젝트 방향 찾기
        dir = dir.normalized;       //단위벡터로 만듦. 1의 크기.  방향만 나온 상태
        float vx = dir.x * speed;
        float vy = dir.y * speed;

        rb.velocity = new Vector2(vx, vy);

        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //이것도 있다

        //플레이어의 움직임에 따라 monster를 Flip
        GetComponent<SpriteRenderer>().flipX = (vx < 0);
    }
}
