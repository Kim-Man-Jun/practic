using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject Enemy;

    void SpawnEnemy()       //적을 생성하는 함수
    {
        float randomX = Random.Range(-2f, 2f);
        if (enableSpawn)
        {
            GameObject go = Instantiate(Enemy, new Vector3(randomX, transform.position.y, -1f), Quaternion.identity);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
