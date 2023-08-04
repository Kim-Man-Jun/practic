using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Spawn : MonoBehaviour
{
    public float left_ss = 0f;
    public float right_es = 0f;
    public float StartTime = 1; 
    public float SpawnStop = 3f;
    public GameObject Monster;

    public bool swi = true;


    void Start()
    {
        StartCoroutine("Delayed_RotateMonsterSpawn");
        StartCoroutine("Stop");
    }

    IEnumerator RotateMonsterSpawn()
    {
        yield return new WaitForSeconds(StartTime);
        float createX = Random.Range(left_ss, right_es);
        Vector2 r = new Vector2(createX, transform.position.y);
        Instantiate(Monster, r, Quaternion.identity);
        swi = true;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(SpawnStop);
        swi = false;
    }

    IEnumerator Delayed_RotateMonsterSpawn()
    {
            yield return new WaitForSeconds(16);
            StartCoroutine("RotateMonsterSpawn");
    
    }
    void Update()
    {
        
    }
}
