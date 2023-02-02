using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f; //총알 속도
    private Rigidbody2D bulletRigidbody; //이동에 사용할 rigidbody 컴포넌트

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bulletRigidbody.velocity = transform.right * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
