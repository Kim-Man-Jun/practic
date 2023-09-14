using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawer : MonoBehaviour
{
    public GameObject[] Enemy;

    BoxCollider2D area;

    public int count = 100;

    List<GameObject> enemyList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponentInChildren<BoxCollider2D>();

        InvokeRepeating("respawn", 0f, Random.Range(0.1f, 5.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void respawn()
    {
        float sizeX = area.transform.position.x;
        float sizeY = area.transform.position.y;

        float randomX = Random.Range(sizeX - 3, sizeX +3);
        float randomY = Random.Range(sizeY - 3, sizeY +3);

        Vector2 spawnPos = new Vector2(randomX, randomY);

        Instantiate(Enemy[0], spawnPos, Quaternion.identity);
    }
}
