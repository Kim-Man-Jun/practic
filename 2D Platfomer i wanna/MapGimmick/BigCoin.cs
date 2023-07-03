using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoin : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public EdgeCollider2D ec;
    public bool coinMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ec = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coinMoving == true)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else if (coinMoving == false)
        {
            rb.velocity = Vector3.zero * Time.deltaTime;    //이동 정지
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stop"))
        {
            coinMoving = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
            ec.isTrigger = false;
        }
    }


}
