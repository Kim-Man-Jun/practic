using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f; //총알 속도

    void Start()
    {

    }

    private void Update()
    {
        if (transform.localScale.x == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else if (transform.localScale.x == -1)
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
