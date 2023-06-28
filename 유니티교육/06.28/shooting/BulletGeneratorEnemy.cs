using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject enemygun2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(프리펩, 생성될 위치, 방향)
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Vector3 dir = this.gameObject.transform.position - enemygun2.transform.position;

            bullet.GetComponent<BulletController>().Shoot(dir * 1000);
        }
    }
}
