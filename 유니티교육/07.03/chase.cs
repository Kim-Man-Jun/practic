using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class E : MonoBehaviour
{
    public Transform destination;

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
        //Vector3 speed = Vector3.zero;
        //transform.position = Vector3.SmoothDamp(transform.position, destination.transform.position, ref speed, 0.1f);

        //slerp (현재 위치, 목표 위치, 보간 간격)
        //반구를 그리면서 추격
        //transform.position = Vector3.Lerp(transform.position, destination.transform.position, 0.01f);
        //transform.position = Vector3.Slerp(transform.position, destination.transform.position, 0.01f);

        Vector3 direction = destination.position - transform.position;         //플레이어를 바리보는 벡터

        direction = direction.normalized;       //1의 크기의 플레이어를 바라보는 벡터가 생성, 단위 벡터

        transform.Translate(direction * 1 * Time.deltaTime);        //플레이어를 바라보는 방향(direction)으로 1의 속도로 움직이기

    }
}
