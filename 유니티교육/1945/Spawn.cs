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
    public GameObject Monster2;
    public GameObject Boss;

    bool swi = true;
    bool swi2 = true;

    [SerializeField] GameObject textBossWarning;

    private void Awake()
    {
        textBossWarning.SetActive(false);
    }
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

        //두번째 몬스터 코루틴
        StartCoroutine("RandomSpawn2");

        //30초 뒤에 2번째 몬스터 스폰을 멈추기
        Invoke("Stop2", SpawnStop + 20);
    }

    void Stop2()
    {
        swi2 = false;
        StopCoroutine("RandomSpawn2");
        //보스출현
        Vector3 pos = new Vector3(0, -68.81f, 0);
        textBossWarning.SetActive(true);
        Instantiate(Boss, pos, Quaternion.identity);
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

    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            //1초마다
            yield return new WaitForSeconds(StartTime + 3);
            //X값 랜덤
            float X = Random.Range(ss, es);
            //X값은 랜덤으로 Y값은 자기자신 좌표
            Vector2 r = new Vector2(X, transform.position.y);
            Instantiate(Monster2, r, Quaternion.identity);
        }
    }
}
