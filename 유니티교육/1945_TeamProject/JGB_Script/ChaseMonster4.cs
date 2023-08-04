using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMonster4 : Monster4
{

    
    void Start()
    {
        //한번 호출
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(HomingBullet, BulletPos.position, Quaternion.identity);

        Invoke("CreateBullet", Delay);
    }

    void Update()
    {
        //아래방향으로 움직여라
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}


