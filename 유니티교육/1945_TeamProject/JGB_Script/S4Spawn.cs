using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S4Spawn : MonoBehaviour
{
    public float ss = -6.5f;   //몬스터 생성 x값 처음
    public float es = 6.5f;    //몬스터 생성 x값 끝
    public float StartTime = 1;  //시작
    public float SpawnStop = 8; //스폰끝내는 시간
    public GameObject monster;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject monster5;
    public GameObject monster6;
    public GameObject Boss;
    public float countdown;
    public float spawntime;
    bool swi = true;
    bool swi2 = true;
    bool swi3 = true;
    bool swi4 = true;
    bool swi5 = false;
    bool bossSpawn = false;
    [SerializeField]
    GameObject textBossWarning; //보스 등장 텍스트 오브젝트

    private void Awake()
    {
        //보스 등장 텍스트 비활성화
         textBossWarning.SetActive(false);

    }


    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", SpawnStop);
    }

    void Stop()
    {
        swi = false;

        StopCoroutine("RandomSpawn");

    }

    private void Update()
    {
        if (bossSpawn == false) { 
        countdown += Time.deltaTime;
        }
        spawntime += Time.deltaTime;

        Monster2Spawn();
        Monster3Spawn();
        Monster4Spawn();
        Monster5Spawn();
        BossSpawn();


    }
    void Monster2Spawn()
    {
        if (countdown > 15)
        {

            if (spawntime > 2)
            {
                if (swi2 == true)
                {
                    spawntime = 0;
                    float X = Random.Range(ss, es);
                    //X값 랜덤값 y값 자기자신값
                    Vector2 rw = new Vector2(X, transform.position.y);
                    Vector2 r = new Vector2(ss, transform.position.y);
                    Vector2 l = new Vector2(es, transform.position.y);
                    Instantiate(monster4, r, Quaternion.identity);
                    Instantiate(monster4, l, Quaternion.identity);
                    Instantiate(monster5, rw, Quaternion.identity);
                }
            }
        }
    }
    void Monster3Spawn()
    {
        if (countdown > 24)
        {
            swi2 = false;
            if (spawntime > 1)
            {

                if (swi3 == true)
                {

                    spawntime = 0;
                    float X = Random.Range(ss, es);

                    float Y = Random.Range(ss, es);
                    //X값 랜덤값 y값 자기자신값
                    Vector2 r = new Vector2(X, transform.position.y);
                    Vector2 rw = new Vector2(Y, transform.position.y);


                    Instantiate(monster3, r, Quaternion.identity);
                    Instantiate(monster5, rw, Quaternion.identity);
                    Instantiate(monster5, rw, Quaternion.identity);
                }
            }
        }

    }
    void Monster4Spawn()
    {
        if (countdown > 30)
        {
            swi3 = false;
            if (spawntime > 4)
            {

                if (swi4 == true)
                {
                    spawntime = 0;
                    float X = Random.Range(ss, es);
                    //X값 랜덤값 y값 자기자신값
                    Vector2 r = new Vector2(X, transform.position.y);
                    Instantiate(monster, r, Quaternion.identity);
                    Instantiate(monster5, r, Quaternion.identity);
                    Instantiate(monster5, r, Quaternion.identity);

                    if (swi5 == true)
                    {
                        Vector2 r6 = new Vector2(ss, transform.position.y);
                        Vector2 l6 = new Vector2(es, transform.position.y);
                        Vector2 r5 = new Vector2(ss + 2, transform.position.y);
                        Vector2 l5 = new Vector2(es - 2, transform.position.y);
                        Instantiate(monster6, r6, Quaternion.identity);
                        Instantiate(monster6, l6, Quaternion.identity);
                        Instantiate(monster4, r5, Quaternion.identity);
                        Instantiate(monster4, l5, Quaternion.identity);
                    }
                    
                }
            }
        }
        
    }
    void Monster5Spawn()
    {
        if (countdown > 40)
        {
            swi5 = true;
        }
        if (countdown > 60) 
        {
            swi4 = false;
            swi5 = false;
            textBossWarning.SetActive(true);
        }
    }

    void BossSpawn() 
    {
        if (countdown > 70)
        {
            bossSpawn = true;
            if (bossSpawn == true) {
                textBossWarning.SetActive(false);
                Vector2 r6 = new Vector2(0, 9);
                Instantiate(Boss, r6, Quaternion.identity);
               
                countdown = 0;
            }
        }
    }
    //코루틴으로 랜덤하게 생성하기
    IEnumerator RandomSpawn()
        {
            while (swi)
            {
                //1초마다
                yield return new WaitForSeconds(StartTime);
                //x값 랜덤
                float X = Random.Range(ss, es);
                //X값 랜덤값 y값 자기자신값
                Vector2 r = new Vector2(X, transform.position.y);
                //몬스터 생성
                Instantiate(monster, r, Quaternion.identity);
            }
        }




    
}
