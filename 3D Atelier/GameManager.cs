using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    List<GameObject> monsters = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //외부에서 넘어온 몬스터가 기존 리스트에 보관하고 있던 몬스터와 일치하는지
    public void AddNewMonster(GameObject mon)
    {
        //넘어온 몬스터가 기존 리스트에 존재하면 true 반환
        bool sameExist = false;

        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i] == mon)
            {
                sameExist = true;

                break;
            }
        }

        if (!sameExist)
        {
            monsters.Add(mon);
        }
    }

    public void RemoveMonster(GameObject mon)
    {
        foreach (GameObject monster in monsters)
        {
            if (monster == mon)
            {
                monsters.Remove(monster);
                break;
            }
        }
    }

    //현재 플레이어가 클릭한 몬스터만 선택마크 표시
    public void ChangeCurrentTarget(GameObject mon)
    {
        DeselectAllMonsters();
        mon.GetComponent<EnemyFSM>().ShowSelection();
    }

    public void DeselectAllMonsters()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            monsters[i].GetComponent<EnemyFSM>().HideSelection();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
