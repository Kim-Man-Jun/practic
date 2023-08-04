using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseNHomingMonster4 : ChaseMonster4

{
    public GameObject target;
    Vector2 dir;
  
    void Start()
    {
        ani = GetComponent<Animator>(); 
        //한번 호출
        Invoke("CreateBullet", Delay);
        
    }

    void CreateBullet()
    {
        Instantiate(HomingBullet, BulletPos.position, Quaternion.identity);

        Invoke("CreateBullet", Delay);
    }

    // Update is called once per frame
    void Update()
    {

       
        target = GameObject.FindGameObjectWithTag("Player");
        //A - B   플레이어 - 미사일    
        if(target != null) { 
        dir = target.transform.position - transform.position;
        transform.Translate(dir * Speed * Time.deltaTime);
            if (dir.x > 0.2f)
            {
                ani.SetBool("Right", true);
                ani.SetBool("Left", false);
                ani.SetBool("Idle", false);
            }
            else if (dir.x < -0.2f)
            {
                ani.SetBool("Left", true);
                ani.SetBool("Right", false);
                ani.SetBool("Idle", false);
            }
            else
            {
                ani.SetBool("Idle", true);
                ani.SetBool("Right", false);
                ani.SetBool("Left", false);
            }
          
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
