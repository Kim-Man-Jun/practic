using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;
    public float speed = 20.0f;
    public Transform FirePos;
    public float cooltime;
    private float curtime;

    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {

                if (Player.transform.localScale.x >= 0)
                {
                    Instantiate(Bullet);                                                                        //총알 생성
                    Bullet.transform.position = FirePos.transform.position;                                     //총알 생성되는 위치는 firepos의 위치
                    Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * speed);                       //총알에 rigidbody 부여 후 오른쪽으로 speed의 힘으로
                }
                else
                {
                    Instantiate(Bullet);
                    Bullet.transform.position = FirePos.transform.position;
                    Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * speed);
                }

            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
