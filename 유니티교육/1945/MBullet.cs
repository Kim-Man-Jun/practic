using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBullet : MonoBehaviour
{
    public GameObject target;
    public float Speed = 3f;
    Vector2 dir;
    Vector2 dirNo;
    public GameObject BoomEffect;

    // Start is called before the first frame update
    void Start()
    {
        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        //플레이어 - 미사일
        dir = target.transform.position - transform.position;
        //방향벡터 구하기, 단위벡터를 1의 크기로 만든다.
        dirNo = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirNo * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Destroy(go, 0.6f);
    }
}

