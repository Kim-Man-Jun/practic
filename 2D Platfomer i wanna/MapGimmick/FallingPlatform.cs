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

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            BoxCollider2D bCol = GetComponent<BoxCollider2D>();
            Rigidbody2D rbody = GetComponent<Rigidbody2D>();


            RemainTime -= Time.deltaTime;

            if (RemainTime <= 0)
            {
                bCol.isTrigger = true;
                rbody.bodyType = RigidbodyType2D.Dynamic;
                Destroy(this.gameObject, 5.0f);
            }
        }
    }
}
