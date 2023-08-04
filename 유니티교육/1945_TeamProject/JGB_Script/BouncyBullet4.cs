using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBullet4 : MonoBehaviour
{
    public float ItemVelocity = 100f;
    Rigidbody2D rig = null;
    Vector2 vec2 = Vector2.down;
    public int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Invoke("TimeCount",1);
    }
    void TimeCount()
    {
        time++;
        if (time == 3)
        {
            Destroy(gameObject);
            time = 0;
        }
        Invoke("TimeCount", 1);
    }
    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }
    void Update()
    {

       rig.AddForce(vec2 * ItemVelocity);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //플레이어 지우기
            // Destroy(collision.gameObject);
            //미사일 지우기
            Debug.Log("충돌함");
            Destroy(gameObject);
        }
    }
}
