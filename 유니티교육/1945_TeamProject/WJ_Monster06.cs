using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Monster06 : MonoBehaviour
{
    public GameObject Monster06;
    public GameObject DropBoss;
    public float StartTime = 1;
    public float spawnStop = 2;
    public bool swi = true;

    void Start()
    {
        StartCoroutine("Delayed_Tank");
        StartCoroutine("Delayed_DropBoss");
        StartCoroutine("Stop");
        StartCoroutine("Stop2");
    }

    IEnumerator CreateTank()
    {
        yield return new WaitForSeconds(StartTime);
        float createX = Random.Range(0, 2);
        Vector2 r = new Vector2(createX, transform.position.y);
        Instantiate(Monster06, r, Quaternion.identity);
        swi=true;
    }

    IEnumerator Create_DropBoss()
    {
        yield return new WaitForSeconds(StartTime);
        float createX = Random.Range(0, 2);
        Vector2 r = new Vector2(createX, transform.position.y);
        Instantiate(DropBoss, r, Quaternion.identity);
        swi = true;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds (spawnStop);
        swi = false;
    }

    IEnumerator Stop2()
    {
        yield return new WaitForSeconds(spawnStop);
        swi = false;
    }

    IEnumerator Delayed_Tank()
    {
        yield return new WaitForSeconds(31);
        StartCoroutine("CreateTank");
    }

    IEnumerator Delayed_DropBoss()
    {
         yield return new WaitForSeconds(59);
         StartCoroutine("Create_DropBoss");
    }

    void Update()
    {
        
    }
}
