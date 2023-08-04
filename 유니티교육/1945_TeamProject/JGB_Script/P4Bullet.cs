using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public int Attack = 10;
    public GameObject effect;



    void Update()
    {
        //미사일이 위쪽방향으로 움직인다.
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

        if (Time.timeScale == 0.5f)
        {
            Speed = 16.0f;
            Destroy(gameObject, 0.5f);
        }
        if (Time.timeScale == 1f)
        {
            Speed = 8.0f;
            Destroy(gameObject, 1f);
        }
        
    }










    //해당코드를 설명하시오.
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }








    // public GameObject effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Monster")
        {
            //아이템 함수호출
            //collision.gameObject.GetComponent<Monster>().ItemDrop();

            ////몬스터 충돌 지우기
            //Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Monster4>().Damage(Attack);
           


            //이펙트 생성하기
            //GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //이펙트 1초뒤에 지우기
            //Destroy(go, 1);


            //미사일 지우기
            Destroy(gameObject);


        }


        if (collision.CompareTag("Boss"))
        {
            //이펙트 생성하기
            //  GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //이펙트 1초뒤에 지우기
            //Destroy(go, 1);


            //미사일 삭제
            collision.gameObject.GetComponent<Boss4>().Damage(Attack);
            Destroy(gameObject);

        }


    }

}
