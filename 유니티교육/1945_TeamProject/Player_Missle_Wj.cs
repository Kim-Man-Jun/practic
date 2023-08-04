using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player_Missle_Wj : MonoBehaviour
{
    public float msSpeed = 7.0f;
    public int Attack = 0;
    public GameObject explosion;
    GameObject[] targets;
    Rigidbody2D rb;

    void Start()
    {
        targets = new GameObject[9];
        targets[0] = GameObject.FindGameObjectWithTag("Monster");
        targets[1] = GameObject.FindGameObjectWithTag("Monster2");
        targets[2] = GameObject.FindGameObjectWithTag("Monster3");
        targets[3] = GameObject.FindGameObjectWithTag("Monster4");
        targets[4] = GameObject.FindGameObjectWithTag("Monster5");
        targets[5] = GameObject.FindGameObjectWithTag("Monster6");
        targets[6] = GameObject.FindGameObjectWithTag("Monster7");
        targets[7] = GameObject.FindGameObjectWithTag("Monster8");
        targets[8] = GameObject.FindGameObjectWithTag("FinalBoss1");

        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
            {
                Vector3 dir = targets[i].transform.position - transform.position;

                dir = dir.normalized;
                float vx = dir.x * msSpeed;
                float vy = dir.y * msSpeed;
                rb.velocity = new Vector2(vx, vy);
                break;
            }
        }
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
        if (collision.tag == "FinalBoss1") 
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<WJ_BossPart1>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.tag == "FinalBoss2")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<WJ_BossPart2>().Damage(Attack);
            Destroy(gameObject);
        }


    }

    private void OnBecameInvisible()    
    {
        Destroy(gameObject);
    }

}
