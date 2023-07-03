using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class E : MonoBehaviour
{
    public GameObject destination;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //현재 위치, 목표 위치, 속력
        //목표 위치를 잘 따라감
        //transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 1 * Time.deltaTime);

        //목표에서 좀 멀었을 때는 빠른 속도로 쫓다가 근처에 왔을 땐 감속해서 접근하는 메서드
        Vector3 speed = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, destination.transform.position, ref speed, 0.1f);
    }
}
