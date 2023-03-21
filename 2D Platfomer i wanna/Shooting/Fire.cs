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
                    Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
                    //bullet를 FirePos.transform.position 위치에 FirePos.transform.rotation 회전값으로 복제한다
                    Bullet.transform.Translate(transform.right * speed * Time.deltaTime);
                }
                else
                {
                    Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
                    Bullet.transform.Translate(transform.right * -1 * speed * Time.deltaTime);
                }

            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
