using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//좌우로 이동 아래로 같이 이동
public class LHS_Item : MonoBehaviour
{
    Vector3 pos;
    float delta = 2.0f; //좌우로 이동가능한 x 최대값

    public float speed = 1f;
    public float flag = 1f;

    void Start()
    {
        pos = transform.position;        
    }

    void Update()
    {
        /*Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;*/

        float h = 0;
        float v = 0;

        //좌우로 이동하면서 아래로 내려가고싶다면? 간격
        v = -1 * 0.5f * Time.deltaTime;

        float addX = pos.x + 0.5f;
        float maineoseuX = pos.x - 0.5f;

        if (transform.position.x >= addX || transform.position.x <= maineoseuX)
        {
            flag *= -1;
        }
        h = flag * speed * Time.deltaTime;

        transform.Translate(h, v, 0);
    }
}
