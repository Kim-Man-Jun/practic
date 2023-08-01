using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 3f;
    public string diretion = "left";    // left or right
    public float range = 0f;
    Vector3 defPos;                     //시작위치

    // Start is called before the first frame update
    void Start()
    {
        if (diretion == "right")
        {
            transform.localScale = new Vector2(-1, 1);
        }

        defPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (range > 0f)
        {
            if (transform.position.x < defPos.x - (range / 2))
            {
                diretion = "right";
                transform.localScale = new Vector2(-1, 1);
            }
            if (transform.position.x > defPos.x + (range / 2))
            {
                diretion = "left";
                transform.localScale = new Vector2(1, 1);
            }
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (diretion == "right")
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (diretion == "right")
        {
            diretion = "left";
            transform.localScale = new Vector2(1, 1);
        }

        if (diretion == "left")
        {
            diretion = "right";
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
