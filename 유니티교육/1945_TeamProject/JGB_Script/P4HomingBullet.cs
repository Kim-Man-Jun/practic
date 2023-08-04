using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4HomingBullet : MonoBehaviour
{
    public GameObject target;
    public GameObject target2;
    public float Speed = 10f;
    Vector2 dir;
    Vector2 dirNo;
    Vector2 dirNo2;
    public int Attack = 30;



    // Start is called before the first frame update
    void Start()
    {   

        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Monster");
        target2 = GameObject.FindGameObjectWithTag("Boss");


        if (target != null ) { 
        //A - B   플레이어 - 미사일    
        dir = target.transform.position - transform.position;
        //방향벡터만 구하기 단위벡터 1의크기로 만든다.
        dirNo = dir.normalized;
        }else
        dirNo =  Vector2.up;

        if (target2 != null)
        {
            //A - B   플레이어 - 미사일    
            dir = target2.transform.position - transform.position;
            //방향벡터만 구하기 단위벡터 1의크기로 만든다.
            dirNo2 = dir.normalized;
        }
        else
            dirNo2 = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.5f)
        {
            Speed = 32.0f;
        }
        if (Time.timeScale == 1f)
        {
            Speed = 16.0f;
        }
        if (target != null) { 
        transform.Translate(dirNo * Speed * Time.deltaTime);
        }else
            transform.Translate(dirNo2 * Speed * Time.deltaTime);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            //플레이어 지우기
            // Destroy(collision.gameObject);
            //미사일 지우기
            collision.gameObject.GetComponent<Monster4>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.tag == "Boss")
        {
            //플레이어 지우기
            // Destroy(collision.gameObject);
            //미사일 지우기
            //collision.gameObject.GetComponent<Monster4>().Damage(Attack);
            collision.gameObject.GetComponent<Boss4>().Damage(Attack);
            Destroy(gameObject);
        }

    }
}
