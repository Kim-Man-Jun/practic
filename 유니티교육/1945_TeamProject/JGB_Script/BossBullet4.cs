using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet4 : MonoBehaviour
{
   
    public float Speed = 5f;
    Vector2 vec2 = Vector2.down;

    void Start()
    {

    }

    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(vec2 * Speed * Time.deltaTime);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //�÷��̾� �����
            // Destroy(collision.gameObject);
            //�̻��� �����
            Debug.Log("�浹��");
            Destroy(gameObject);
        }
    }
}

