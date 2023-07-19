using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float ss = -3;               //몹 생성 x값 처음
    public float es = 3;                //몹 생성 x값 끝
    public float StartTime = 1;         //스폰 시간 시작
    public float SpawnStop = 10;        //스폰 시간 끝
    public GameObject Monster;

    bool swi = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", SpawnStop);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Stop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");
    }

    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            //1초마다
            yield return new WaitForSeconds(StartTime);
            //X값 랜덤
            float X = Random.Range(ss, es);
            //X값은 랜덤으로 Y값은 자기자신 좌표
            Vector2 r = new Vector2(X, transform.position.y);
            Instantiate(Monster, r, Quaternion.identity);
        }
    }
}
