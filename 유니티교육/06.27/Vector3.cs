using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    Rigidbody Ball;
    public float speed = 100.0f;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GetComponent<Rigidbody>();
        startPos = new Vector3(0, 0, 0);
        Ball.AddForce(-speed, 0f, speed * 0.7f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            Vector3 currPos = coll.transform.position;

            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = coll.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            Ball.AddForce(reflectVec * speed);
        }
        startPos = transform.position;

        if (coll.gameObject.CompareTag("object"))
        {
            Destroy(coll.gameObject);

            Vector3 currPos = coll.transform.position;

            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = coll.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            Ball.AddForce(reflectVec * speed);
        }
        startPos = transform.position;
    }
}
