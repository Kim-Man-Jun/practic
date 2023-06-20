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

    private void OnCollision2D(Collider2D other)
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        BoxCollider2D bCol = GetComponent<BoxCollider2D>();

        bCol.isTrigger = true;

        if (other.gameObject.tag == "Player")
        {
            if (rbody.bodyType == RigidbodyType2D.Static)
            {
                RemainTime -= Time.deltaTime;

                if (RemainTime <= 1)
                {
                    rbody.bodyType = RigidbodyType2D.Dynamic;

                    Destroy(this.gameObject, 5.0f);
                }
            }
        }
    }
}
