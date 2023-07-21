using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    public int Attack = 100;
    public GameObject BoomEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<PlayerController>().pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            //collision.gameObject.GetComponent<Monster>().ItemDrop();
            collision.gameObject.GetComponent<Monster>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss>().Damage(Attack);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BossParts")
        {
            GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
            Destroy(go, 1);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
