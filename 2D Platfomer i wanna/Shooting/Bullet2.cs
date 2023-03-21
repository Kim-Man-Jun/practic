using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;

    public float speed = 20.0f; //총알 속도

    void Start()
    {

    }

    private void Update()
    {
        if (player.transform.localScale.x >= 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);          //총알을 오른쪽으로 보냄
        }
        else if (player.transform.localScale.x == -1)
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);     //총알을 왼쪽으로 보냄
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
