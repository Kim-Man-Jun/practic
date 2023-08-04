using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scuzy_Monster : MonoBehaviour
{
    public GameObject Sacrifice;
    public float moveSpeed = 15f;
    public int HP = 3;
    public int m_Attack = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = moveSpeed * Time.deltaTime;
        transform.Translate(0, -moveY, 0);
    }
    public void Damage(int Attack)
    {
        HP -= Attack;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(Sacrifice, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Player>().Damage(m_Attack);
            Destroy(gameObject);
        }
    }
}
