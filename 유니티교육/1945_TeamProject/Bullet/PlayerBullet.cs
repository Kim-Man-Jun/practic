using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float Speed = 8.0f;
    public int Attack;
    public GameObject BoomEffect;
    Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.AddForce(new Vector2(0, Speed * Time.deltaTime), ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

        }

        if (collision.gameObject.tag == "Boss")
        {

        }

        if (collision.gameObject.tag == "BossParts")
        {

        }
    }
}
