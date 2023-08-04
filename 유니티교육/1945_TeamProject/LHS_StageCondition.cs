using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_StageCondition : MonoBehaviour
{
    //State에 있는 몬스터들
    List<GameObject> MonsterListInRoom = new List<GameObject>();

    //굳이?
    //플레이어가 방에 있는지
    public bool playerInThisRoom = false;
    public bool isClearRoom = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //플레이어가 방에 들어오면 이 방의 몹 리스트를 복사시킨다.
            playerInThisRoom = true;
            //플레이어 타겟팅 static으로
        }
        if(collision.CompareTag("Monster"))
        {
            MonsterListInRoom.Add(collision.gameObject);
            //Debug.Log("Mob name" + collision.gameObject.name);
        }
    }
}
