using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float RemainTime;

    void Start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        BoxCollider2D bCol = GetComponent<BoxCollider2D>();

        RemainTime -= Time.deltaTime;

        if (RemainTime <= 0)
        {
            bCol.isTrigger = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();

        if (other.gameObject.tag == "Player")
        {
            if (rbody.bodyType == RigidbodyType2D.Static)
            {
                rbody.bodyType = RigidbodyType2D.Dynamic;

                Destroy(this.gameObject, 5.0f);
            }
        }
    }
}
