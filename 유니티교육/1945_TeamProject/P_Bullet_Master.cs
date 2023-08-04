using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet_Master : MonoBehaviour
{
    public float bulletSpeed = 6f;
    public float spreadAngle = 30f; 
    public int numBullets = 5;
    public int Attack = 0;
    public GameObject explosion;

    void Start()
    {
        SpreadFire();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    void SpreadFire()
    {
        float startAngle = -spreadAngle / 2f;
        for(int i = 0; i < numBullets; i++)
        {
            GameObject pBullet = Instantiate(gameObject,transform.position , Quaternion.identity);

            float angle = startAngle + (spreadAngle / (numBullets - 1)) * i;
            pBullet.transform.rotation = Quaternion.Euler(0f,0f,angle);
        }
        Destroy(gameObject);
    }
}
