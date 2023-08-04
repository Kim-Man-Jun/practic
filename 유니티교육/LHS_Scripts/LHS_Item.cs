using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//�¿�� �̵� �Ʒ��� ���� �̵�
public class LHS_Item : MonoBehaviour
{
    Vector3 pos;
    float delta = 2.0f; //�¿�� �̵������� x �ִ밪

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

        //�¿�� �̵��ϸ鼭 �Ʒ��� ��������ʹٸ�? ����
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
