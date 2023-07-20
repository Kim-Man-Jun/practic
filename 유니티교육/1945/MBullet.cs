using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float Speed = 5f;

    public GameObject BoomEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }

    //private void OnDestroy()
    //{
    //    GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
    //    Destroy(go, 0.6f);
    //}
}

