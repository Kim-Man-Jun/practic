using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObj : MonoBehaviour
{
    List<Transform> spawnPos = new List<Transform>();
    GameObject[] monsters;

    public GameObject monPrefab;
    public int spawnNumber = 1;
    public float respawnDelay = 3f;

    int deadMonsters = 0;

    // Start is called before the first frame update
    void Start()
    {
        MakeSpawnPos();
    }

    private void MakeSpawnPos()
    {
        foreach (Transform pos in transform)
        {
            if (pos.tag == "Respawn")
            {
                spawnPos.Add(pos);
            }
        }
        if (spawnNumber > spawnPos.Count)
        {
            spawnNumber = spawnPos.Count;
        }

        monsters = new GameObject[spawnNumber];

        MakeMonsters();
    }

    private void MakeMonsters()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            GameObject mon = Instantiate(monPrefab, spawnPos[i].position, Quaternion.identity) as GameObject;

            mon.GetComponent<EnemyFSM>().SetRespawnObj(gameObject, i, spawnPos[i].position);

            mon.SetActive(false);

            monsters[i] = mon;

            GameManager.instance.AddNewMonster(mon);
        }
    }

    public void RemoveMonster(int spawnID)
    {
        deadMonsters++;

        monsters[spawnID].SetActive(false);
        print(spawnID + "'s monster was Killed");

        //죽은 몬스터의 숫자가 몬스터 배열의 크기와
        //같다면 일정 시간 후에 몬스터를 다시 생성
        if(deadMonsters == monsters.Length)
        {
            StartCoroutine(InitMonsters());
            deadMonsters = 0;
        }

    }

    IEnumerator InitMonsters()
    {
        yield return new WaitForSeconds(respawnDelay);

        GetComponent<SphereCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpawnMonster();
            GetComponent<SphereCollider>().enabled = false;
        }
    }

    private void SpawnMonster()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            monsters[i].GetComponent<EnemyFSM>().AddToWorldAgain();
            monsters[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
