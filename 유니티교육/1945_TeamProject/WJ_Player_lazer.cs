using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Player_lazer : MonoBehaviour
{
    public GameObject explosion;
    public int Attack = 10;
    Transform pos;
    GameObject Spot;

    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<Player>().lzPos;
        Spot = GameObject.Find("MoveSpot");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().Damage(Attack);
        }
        if (collision.tag == "Monster2")
        {
            collision.gameObject.GetComponent<lv1_L_Monster>().Damage(Attack);
        }
        if (collision.tag == "Monster3")
        {   
            collision.gameObject.GetComponent<lv1_R_Monster>().Damage(Attack);
        }
        if (collision.tag == "Monster4")
        {
            collision.gameObject.GetComponent<LV2_Monster>().Damage(Attack);
        }
        if (collision.tag == "Monster5")
        {
            collision.gameObject.GetComponent<R_Monster_sc>().Damage(Attack);
        }
        if (collision.tag == "Monster6")
        {
            collision.gameObject.GetComponent<WJ_Rotate_Attack>().Damage(Attack);
        }
        if (collision.tag == "Monster7")
        {
            collision.gameObject.GetComponent<Scuzy_Monster>().Damage(Attack);
        }
        if (collision.tag == "Monster8")
        {
            collision.gameObject.GetComponent<Lazer_Monster_wj>().Damage(Attack);
        }
        if (collision.tag == "Boss1")
        {
            collision.gameObject.GetComponent<Drop_Monster_wj>().Damage(Attack);
            Instantiate(explosion, Spot.transform.position, Quaternion.identity);
        }
        if (collision.tag == "BossParts")
        {
            collision.gameObject.GetComponent<WJ_Boss_ex>().Damage(Attack);
            Instantiate(explosion, Spot.transform.position, Quaternion.identity);
        }
        if (collision.tag == "FinalBoss1")
        {
            collision.gameObject.GetComponent<WJ_BossPart1>().Damage(Attack);
            Instantiate(explosion, Spot.transform.position, Quaternion.identity);
        }
        if (collision.tag == "FinalBoss2")
        {
            collision.gameObject.GetComponent<WJ_BossPart2>().Damage(Attack);
            Instantiate(explosion, Spot.transform.position, Quaternion.identity);
        }
    }
}
