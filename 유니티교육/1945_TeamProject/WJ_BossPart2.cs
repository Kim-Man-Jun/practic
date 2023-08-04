using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WJ_BossPart2 : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float startWaitTime;
    private float waitTime;
    public float StartTime = 1;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    //

    public int HP = 4000;

    public Transform moveSpot;
    public Transform Tooth_Pos;
    public Transform ms1;
    public Transform ms2;
    public Transform ms3;
    public Transform BuriMS;
    public Transform EYE1;
    public Transform EYE2;

    public GameObject Item = null;
    public GameObject BossExplosion;
    public GameObject L_thunder;
    public GameObject R_thunder;
    public GameObject tooth_Bullet;
    public GameObject Mbullet;
    public GameObject drill;

    GameObject Spot;
    Rigidbody2D rb;

    void Start()
    {
        Spot = GameObject.Find("MoveSpot");
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        Invoke("CreateBullet", 1);
        Invoke("CreateDrill", 7);
        StartCoroutine(CircleFire());
        Invoke("Thunder", 2f);
    }

    void CreateBullet()
    {
        Instantiate(Mbullet, ms3.position, Quaternion.identity);
        Invoke("CreateBullet", 1);
    }
    void CreateDrill()
    {
        Instantiate(drill, BuriMS.position, Quaternion.identity);
        Invoke("CreateDrill", 5);
    }

    //회전공격
    IEnumerator CircleFire()
    {

        float attackRate = 10f;
        int count = 40;
        float intervalAngle = 360 / count;
        float weightAngle = 120;

        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                GameObject clone = Instantiate(tooth_Bullet, transform.position, Quaternion.identity);

                float angle = weightAngle + intervalAngle * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                clone.GetComponent<rotate_bullet_wj>().Move(new Vector2(x, y));
            }
            weightAngle += 1;
            yield return new WaitForSeconds(attackRate);
        }
    }
    private void FixedUpdate()
    {
        float dis = Vector3.Distance(Spot.transform.position, transform.position);
        if (dis > 1.2f)
        {

            Vector3 dir = Spot.transform.position - transform.position;
            dir = dir.normalized;
            float vx = dir.x * moveSpeed;
            float vy = dir.y * moveSpeed;
            rb.velocity = new Vector2(vx, vy);
        }
    }
    void Thunder()
    {
        Instantiate(L_thunder, EYE1.transform.position, Quaternion.identity);
        Instantiate(R_thunder, EYE2.transform.position, Quaternion.identity);
        Invoke("Thunder", 8f);
    }

    public void Damage(int Attack)
    {
        HP -= Attack;
        if (HP <= 0)
        {
            Instantiate(BossExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
