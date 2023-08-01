using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float Speed = 8.0f;
    public int Attack;
    public GameObject BoomEffect;
    Rigidbody2D Rigidbody;
    AudioSource PB;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        PB = GetComponent<AudioSource>();

        PB.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.AddForce(new Vector2(0, Speed * Time.deltaTime), ForceMode2D.Impulse);

        if(gameObject.transform.position.y >= -16.18f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().Damage(Attack);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<BossController>().Damage(Attack);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BossParts")
        {
            //collision.gameObject.GetComponent<BossPartsController>().Damage(Attack);
            Destroy(gameObject);
        }
    }
}
