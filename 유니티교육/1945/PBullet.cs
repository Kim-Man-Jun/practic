using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float speed = 8.0f;
    public GameObject BoomEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Destroy(go, 0.6f);
    }
}
