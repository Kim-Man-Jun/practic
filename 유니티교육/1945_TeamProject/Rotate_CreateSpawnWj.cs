using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_CreateSpawnWj : MonoBehaviour
{
    public float left_ss = -2.0f;
    public float right_es = 0f;
    public float StartTime = 1;
    public float SpawnStop = 3;
    public GameObject Monster;

    public bool swi = true;

    void Start()
    {
        StartCoroutine("Delayed_RotateMonsterSpawn2");
        StartCoroutine("Stop");
    }

    IEnumerator RotateMonsterSpawn2()
    {
        yield return new WaitForSeconds(StartTime);
        float createX = Random.Range(left_ss, right_es);
        Vector2 r = new Vector2(createX, transform.position.y);
        Instantiate(Monster, r, Quaternion.identity);
        swi = true;

        yield return new WaitForSeconds(StartTime + 1f);

        createX = Random.Range(left_ss, right_es);
        r = new Vector2(createX, transform.position.y);
        Instantiate(Monster, r, Quaternion.identity);
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(SpawnStop);
        swi = false;
    }

    IEnumerator Delayed_RotateMonsterSpawn2()
    {
        yield return new WaitForSeconds(21);
        StartCoroutine("RotateMonsterSpawn2");

    }
    void Update()
    {

    }
}
