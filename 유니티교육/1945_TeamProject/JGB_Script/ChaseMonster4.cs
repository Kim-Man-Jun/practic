using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMonster4 : Monster4
{

    
    void Start()
    {
        //�ѹ� ȣ��
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(HomingBullet, BulletPos.position, Quaternion.identity);

        Invoke("CreateBullet", Delay);
    }

    void Update()
    {
        //�Ʒ��������� ��������
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}


