using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{   //y 4.7, x 1.5

    public float left_ss = -2.95f;
    public float left_es = -2.4f;
    public float up_ss = 5.3f;
    public float up_es = 2.6f;

    public float StartTime = 1;
    public float SpawnStop = 15;
    public GameObject Monster;
    public GameObject Monster2;

    bool swi = true;

    void Start()
    {
        StartCoroutine("RandomSpawn");
        StartCoroutine("Stop");
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(SpawnStop);
        swi = false;
    }

    IEnumerator RandomSpawn()
    {
        while(swi)
        {
            yield return new WaitForSeconds(StartTime + 5);
            float createX = Random.Range(left_ss, left_es);
            float createY = Random.Range(up_ss, up_es);
            Vector2 r = new Vector2(createX, createY);
            Instantiate(Monster, r, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
