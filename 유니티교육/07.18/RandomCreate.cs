using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreate : MonoBehaviour
{
    public GameObject nowPrefab;        //생성할 프리팹
    public float intervalSec = 1;       //생산 간격

    // Start is called before the first frame update
    void Start()
    {
        //지정 초마다 CreatePrefab을 반복하는 실행 요약
        InvokeRepeating("CreatePrefab", intervalSec, intervalSec);
    }

    void CreatePrefab()
    {
        //오브젝트 범위 가져오기
        Vector3 area = GetComponent<SpriteRenderer>().bounds.size;

        Vector3 newPos = transform.position;
        newPos.x += Random.Range(-area.x / 2, area.x / 2);
        newPos.y += Random.Range(-area.y / 2, area.y / 2);
        newPos.z = -5;

        GameObject newGameOject = Instantiate(nowPrefab);
        newGameOject.transform.position = newPos;
    }

}
