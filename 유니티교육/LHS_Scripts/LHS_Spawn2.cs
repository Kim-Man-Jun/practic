using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//다섯 간격으로 발사하고 싶음
public class LHS_Spawn2 : MonoBehaviour
{
    //몬스터 생성 x 값
    public float ss = -2; //시작
    public float es = 2; //끝

    public float StartTime = 1; //시작
    public float SpawnTime = 10; //스폰 끝내는 시감

    [Header("단계별 몬스터")]
    public GameObject[] monster;

    public GameObject textBossWarning; // 보스 등장 텍스트 오브젝트
    public GameObject BossBar; // 보스 등장 텍스트 오브젝트

    //보스 나와야함
    //보스 UI
    private void Awake()
    {
        
    }

    void Start()
    {
        /*textBossWarning.SetActive(true);
        BossBar.SetActive(true);*/
        Invoke("Monster1", SpawnTime);
    }

    void Update()
    {
        /*if(LHS_GameManager.instance.stageCheck == 2)
        {
            //스테이지 2가기 위함
            transform.GetChild(0).gameObject.SetActive(true);
        }*/
    }
    
    void Monster1()
    {
        Instantiate(monster[0], transform.position, Quaternion.identity);
        Invoke("Monster2", SpawnTime + 5);
    }

    void Monster2()
    {
        textBossWarning.SetActive(true);
        BossBar.SetActive(true);
        Instantiate(monster[1], transform.position, Quaternion.identity);
        //Invoke("Monster3", SpawnTime + 10);
    }
    
    void Monster3()
    {
        Instantiate(monster[2], new Vector2(1.4f, transform.position.y), Quaternion.identity);
        Invoke("Monster4", SpawnTime + 3);
    }

    void Monster4()
    {
        Instantiate(monster[2], new Vector2(-1.4f, transform.position.y), Quaternion.identity);
        Invoke("Monster5", SpawnTime + 5);
    }

    void Monster5()
    {
        Instantiate(monster[3], transform.position, Quaternion.identity);
    }
}
