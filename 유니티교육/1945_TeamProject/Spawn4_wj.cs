using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn4_wj : MonoBehaviour
{
    //============================
    float lazer_ss = -2.6f;
    float lazer_es = -1.4f;

    float lazer_ss2 = -0.65f;
    float lazer_es2 = 0.62f;

    float lazer_ss3 = 1.35f;
    float lazer_es3 = 2.6f;

    //============================

    public float left_ss = -2.5f;
    public float right_es = 2.5f;

    //============================

    public float StartTime = 1;
    public float SpawnStop = 10;
    public GameObject Monster;
    public GameObject Monster2;

    bool swi = true;

    void Start()
    {
        StartCoroutine("Delyaed_Lazer");
        StartCoroutine("Delayed_Scurzy");
        StartCoroutine("Stop");
        StartCoroutine("Stop2");
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(SpawnStop);
        swi = false;
    }
    IEnumerator Stop2()
    {
        yield return new WaitForSeconds(SpawnStop);
        swi = false;
    }

    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            yield return new WaitForSeconds(StartTime + 2);
            float createX = Random.Range(lazer_ss, lazer_es);
            Vector2 r = new Vector2(createX, transform.position.y);
            Instantiate(Monster, r, Quaternion.identity);

            float createX2 = Random.Range(lazer_ss2, lazer_es2);
            Vector2 r2 = new Vector2(createX2, transform.position.y);
            Instantiate(Monster, r2, Quaternion.identity);

            float createX3 = Random.Range(lazer_ss3, lazer_es3);
            Vector2 r3 = new Vector2(createX3, transform.position.y);
            Instantiate(Monster, r3, Quaternion.identity);
        }
    }

    IEnumerator RandomSpawn2()
    {
        while (swi)
        {
            yield return new WaitForSeconds(StartTime + 4);
            float createX = Random.Range(left_ss, right_es);
            Vector2 r = new Vector2(createX, transform.position.y);
            Instantiate(Monster2, r, Quaternion.identity);
        }
    }

    IEnumerator Delyaed_Lazer()
    {
        yield return new WaitForSeconds(35);
        StartCoroutine("RandomSpawn");
    }

    IEnumerator Delayed_Scurzy()
    {
        yield return new WaitForSeconds(40);
        StartCoroutine("RandomSpawn2");
        
    }

    void Update()
    {
        
    }
}
