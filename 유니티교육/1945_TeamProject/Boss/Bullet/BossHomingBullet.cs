using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHomingBullet : MonoBehaviour
{
    public GameObject Target_Player;

    public float Speed = 10f;
    public int Power = 20;

    Vector2 dir;
    Vector2 dirNo;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Target_Player = GameObject.FindGameObjectWithTag("Player");
        dir = Target_Player.transform.position - transform.position;
        dirNo = dir.normalized;

        rb.AddForce(dirNo * Speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Damage(Power);
            Destroy(gameObject);
        }
    }
}
