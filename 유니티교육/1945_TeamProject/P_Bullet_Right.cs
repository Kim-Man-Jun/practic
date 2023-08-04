using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet_Right : MonoBehaviour
{
    public float B_speed = 8.0f;
    public int Attack = 0;
    public GameObject explosion;
   // public Transform[] AdditionalBulletSpawnPoints; // 추가 발사 위치들을 배열로 관리합니다.

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * B_speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Monster>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.tag == "Monster2")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<lv1_L_Monster>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.tag == "Monster3")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<lv1_R_Monster>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.tag == "Monster4")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<LV2_Monster>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.tag == "Monster5")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<R_Monster_sc>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.tag == "Monster6")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<WJ_Rotate_Attack>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.tag == "Monster7")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Scuzy_Monster>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.tag == "Monster8")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Lazer_Monster_wj>().Damage(Attack);
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
