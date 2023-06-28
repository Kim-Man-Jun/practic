using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool chartouch = false;
    public float RemainTime;
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

        if (RemainTime <= curTime)
        {
            bCol.isTrigger = true;
            rbody.bodyType = RigidbodyType2D.Dynamic;
            bCol.enabled = false;
            Destroy(this.gameObject, 5.0f);
            chartouch = false;
        }
    }
}
// 블록이 떨어질때 애니메이션이 대기상태로 되어 있는걸 remain 타임 끝나면 collider 자체를 off하는 식으로
// 수정을 해서 떨어질때 점프 애니메이션을 on 하도록 만들었음
