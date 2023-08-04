using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Monster_sc : MonoBehaviour
{
    public Transform ms;
    public GameObject Mbullet;
    public GameObject DeathMonster;
    public float moveSpeed = 1f;
    public float Delay;
    public float HP = 3;


    private void Start()
    {
        Invoke("CreateBullet",Delay);
    }

    void CreateBullet()
    {
        WJ_SoundManager.instance.HomingMonster();
        Instantiate(Mbullet, ms.position, Quaternion.identity);
        Invoke("CreateBullet", Delay);
    }
    public void Damage(int Attack)
    {
        HP -= Attack;
        if (HP <= 0)
        {
            Instantiate(DeathMonster, transform.position, Quaternion.identity);
            WJ_SoundManager.instance.ExplosionSound();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
       transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
