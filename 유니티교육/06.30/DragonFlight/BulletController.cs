using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject BulletPrb;
    public float ShootTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 0, ShootTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void shoot()
    {
        Instantiate(BulletPrb, transform.position, Quaternion.identity);
        //사운드 사용
        SoundManager.instance.PlaySound();
    }
}
