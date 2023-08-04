using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class boss_light : MonoBehaviour
{
    public GameObject Player_Death;
    public int m_Attack = 300;
    Transform pos1;
    void Start()
    {
        pos1 = GameObject.FindGameObjectWithTag("FinalBoss2").GetComponent<WJ_BossPart2>().EYE1;
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos1.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(Player_Death, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Player>().Damage(m_Attack);
            Destroy(gameObject);
        }
    }
}
