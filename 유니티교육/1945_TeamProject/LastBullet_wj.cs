using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBullet_wj : MonoBehaviour
{
    public GameObject Player_Death;
    public int m_Attack = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
