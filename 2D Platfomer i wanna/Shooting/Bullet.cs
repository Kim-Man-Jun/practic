using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public gameObject player;
    
    public float speed = 20.0f; //총알 속도

    void Start()
    {

    }

    private void Update()
    {
        if (player.transform.localScale.x >= 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else if (player.transform.localScale.x == -1)
        {
            transform.Translate(transform.left * speed * Time.deltaTime);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
