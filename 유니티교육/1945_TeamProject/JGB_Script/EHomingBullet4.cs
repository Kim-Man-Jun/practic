using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHomingBullet4 : MonoBehaviour
{
    public GameObject target;
    public float Speed = 3f;
    Vector2 dir;
    Vector2 dirNo;
    public GameObject player;


    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        if(player != null) { 
        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        //A - B   플레이어 - 미사일    
        dir = target.transform.position - transform.position;
        //방향벡터만 구하기 단위벡터 1의크기로 만든다.
        dirNo = dir.normalized;
        }

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(dirNo * Speed * Time.deltaTime);
        if (player == null)
        {
            Destroy(gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //플레이어 지우기
            // Destroy(collision.gameObject);
            //미사일 지우기
            Destroy(gameObject);
        }
    }
}
