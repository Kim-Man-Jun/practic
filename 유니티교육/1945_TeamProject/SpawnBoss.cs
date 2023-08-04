using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    //public float left_ss = -1f;
    //public float right_es = 1f;

    //public float StartTime = 1; //시작

    //public GameObject FinalBoss1;
    //public GameObject FinalBoss2;

    //void Start()
    //{
    //    StartCoroutine("BossSpawn");
    //    StartCoroutine("BossSpawn2");
    //    StartCoroutine("Stop");
    //}
    //void Stop()
    //{

    //}

    //public IEnumerator BossSpawn()
    //{
    //    Drop_Monster_wj FBoss1 = FindObjectOfType<Drop_Monster_wj>();
    //    if (FBoss1 != null && FBoss1.HP <= 0)
    //    {
    //        Debug.Log("보스가 출현합니다.");
    //        yield return new WaitForSeconds(StartTime);
    //        float createX = Random.Range(left_ss, right_es);
    //        Vector2 r = new Vector2(createX, transform.position.y);
    //        Instantiate(FinalBoss1, r, Quaternion.identity);
    //    }
            
       
    //}
    //IEnumerator BossSpawn2()
    //{
    //    WJ_BossPart1 FBoss2 = FindObjectOfType<WJ_BossPart1>();
    //    if (FBoss2 != null && FBoss2.HP <= 0)
    //    {
    //        Debug.Log("마지막 보스가 출현합니다.");
    //        yield return new WaitForSeconds(StartTime + 3);
    //        float createX = Random.Range(left_ss, right_es);
    //        Vector2 r = new Vector2(createX, transform.position.y);
    //        Instantiate(FinalBoss2, r, Quaternion.identity);
    //    }
    //}
}
