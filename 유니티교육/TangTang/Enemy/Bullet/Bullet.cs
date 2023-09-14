using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    Vector2 forward;

    Rigidbody2D rb;
    private void Awake()
    {
        forward = GameObject.FindGameObjectWithTag("Player").
            GetComponent<mouseShoot>().mousePointer.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, forward, speed * Time.deltaTime);
        transform.Translate(forward * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 1f);
    }
}
