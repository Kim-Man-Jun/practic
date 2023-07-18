using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChase : MonoBehaviour
{
    Vector3 basepos;        //카메라 위치 담기

    // Start is called before the first frame update
    void Start()
    {
        basepos = Camera.main.transform.position;       //카메라 원래 위치 저장
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;       //자신의 위치
        pos.z = basepos.z;
        pos.y = basepos.y - 5;

        Camera.main.transform.position = pos;
    }
}
