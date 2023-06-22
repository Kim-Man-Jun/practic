using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool chartouch = false;
    public int RemainTime;
    float curTime;

    void Start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
    }
    private void Update()
    {
        if (chartouch == true)
        {
            curTime += Time.fixedDeltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D Player)
    {
        if (chartouch == false)
        {
            chartouch = true;
        }

        BoxCollider2D bCol = GetComponent<BoxCollider2D>();
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();

        Debug.Log(curTime);

        if (RemainTime <= curTime)
        {
            bCol.isTrigger = true;
            rbody.bodyType = RigidbodyType2D.Dynamic;
            Destroy(this.gameObject, 5.0f);
            chartouch = false;
        }
    }
}
