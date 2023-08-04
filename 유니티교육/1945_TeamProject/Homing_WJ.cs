using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_WJ : MonoBehaviour
{
    public float BSpeed = 2.0f;
    public GameObject Player_Death;
    public int m_Attack = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * BSpeed * Time.deltaTime);
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
