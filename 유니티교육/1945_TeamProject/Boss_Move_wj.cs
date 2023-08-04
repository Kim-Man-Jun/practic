using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Move_wj : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float startWaitTime;
    private float waitTime;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    //
    public Transform moveSpot;


    void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX),
        Random.Range(minY, maxY));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position,
            moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
