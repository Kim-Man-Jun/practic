using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int HP = 100;
    public float Speed = 5f;
    public float Delay = 1f;
    public Transform ms;
    public Transform ms2;
    public GameObject bullet;
    public static int RandomPos;

    public GameObject BoomEffect;

    public GameObject Item = null;

    public int Direction;       //1일 경우 왼쪽, 2일 경우 정면, 3일 경우 오른쪽

    public bool EnemyStart = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBullet", 0.5f, Delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -Speed * Time.deltaTime));

        if (gameObject.transform.position.x > 2.6f)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.x < -2.6f)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.y < -25f)
        {
            Destroy(gameObject);
        }
    }

    void CreateBullet()
    {
        if (EnemyStart == true)
        {
            if (ms != null)
            {
                Instantiate(bullet, ms.position, Quaternion.identity);
            }

            if (ms2 != null)
            {
                Instantiate(bullet, ms2.position, Quaternion.identity);
            }
        }
    }

    public void Damage(int attack)
    {
        HP -= attack;

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Destroy(go, 0.5f);

        if (Item != null)
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
    }
}
