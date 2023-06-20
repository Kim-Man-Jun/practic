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
        BoxCollider2D bCol = GetComponent<BoxCollider2D>();
        bCol.isTrigger = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        BoxCollider2D bCol = GetComponent<BoxCollider2D>();

        if (other.gameObject.tag == "Player")
        {
            bCol.isTrigger = true;

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

// 방향을 바꿔보자
// 스태틱에서 다이나믹으로 바꾸는건 맞나?
// 차라리 무게를 부여하는 식으로 변경을 해봐야하나
