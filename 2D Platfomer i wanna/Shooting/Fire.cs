using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Player;
    public flaot speed = 20.0;
    public Transform FirePos;
    public float cooltime;
    private float curtime;

    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                GameObject Bullet = Instantiate(BulletPrefab, FirePos.transform.position, FirePos.transform.rotation);
                //bullet를 FirePos.transform.position 위치에 FirePos.transform.rotation 회전값으로 복제한다
                
                if(Player.transform.localScale.x >= 0)
                {
                    Bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed * Time.deltaTime);
                }
                else
                {
                    Bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * -1 * speed * Time.deltaTime);
                }

            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
