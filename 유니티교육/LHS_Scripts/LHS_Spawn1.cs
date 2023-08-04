using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//다섯 간격으로 발사하고 싶음
public class LHS_Spawn1 : MonoBehaviour
{
    //몬스터 생성 x 값
    public float ss = -2; //시작
    public float es = 2; //끝

    public float StartTime = 1; //시작
    public float SpawnTime = 10; //스폰 끝내는 시감

    [Header("단계별 몬스터")]
    public GameObject[] monster;

    private void Awake()
    {
        
    }

    void Start()
    {
        Invoke("Monster1", SpawnTime);
    }

    void Update()
    {
        if(LHS_GameManager.instance.stageCheck == 2)
        {
            //스테이지 2가기 위함
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    
    void Monster1()
    {
        Instantiate(monster[0], transform.position, Quaternion.identity);

        Invoke("Monster2", SpawnTime + 5);
        /*//x 값 랜덤
        float x = Random.Range(ss, es);
        //x 값 랜덤값 y값 자기 자신 값
        Vector2 r = new Vector2(x, transform.position.y);
        
        for(int i = 0; i < 5; i ++)
        {
            //몬스터 생성
            Instantiate(monster[0],new Vector2(ss + i, transform.position.y), Quaternion.identity);
        }*/
    }

    void Monster2()
    {
        Instantiate(monster[1], transform.position, Quaternion.identity);
        Invoke("Monster3", SpawnTime + 10);
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
