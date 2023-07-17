using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CarMoveForever : MonoBehaviour
{
    public float speed = 5;

    Rigidbody2D rbdoy;

    // Start is called before the first frame update
    void Start()
    {
        rbdoy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rbdoy.velocity = new Vector2(speed, 0);     //수평이동 물리적인 움직임
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            speed = -speed;

            if (speed < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
