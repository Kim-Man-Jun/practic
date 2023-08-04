using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv1_R_Monster : MonoBehaviour
{
    public Transform ms;
    public GameObject Mbullet;
    public GameObject Item = null;
    public GameObject DeathMonster;
    public float HP = 15;
    public float moveSpeed = 2f;
    public float Delay = 1;
    public float drop = 5f;
    public Vector3 moveDirection = new Vector3(-1,-1,0);
    void Start()
    {
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(Mbullet,ms.position,Quaternion.identity);
        Invoke("CreateBullet", Delay);
    }
    public void ItemDrop()
    {
        float randomValue = Random.Range(0f, 100f);
        if (randomValue <= drop)
        {
            Instantiate(Item, ms.position, Quaternion.identity);
        }
    }
    public void Damage(int Attack)
    {
        HP -= Attack;
        if (HP <= 0)
        {
            ItemDrop();
            Instantiate(DeathMonster, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Update()
    {
     transform.Translate(moveDirection * moveSpeed * Time.deltaTime);   
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

