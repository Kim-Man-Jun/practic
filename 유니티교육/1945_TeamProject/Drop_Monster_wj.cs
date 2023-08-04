using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drop_Monster_wj : MonoBehaviour
{
    [SerializeField]
    GameObject textBossWarning; //보스등장 오브젝트

    public Transform ms1;
    public Transform ms2;
    public Transform ms3;
    public GameObject Drop_Bullet;
    public GameObject Drop_Ms_Bullet;
    public GameObject Item = null;
    public GameObject DeadBoss; 
    public GameObject FinalBoss1;
    public GameObject BossExplosion;
    //
    public int HP = 350;
    public int drop = 15;
    public int flag = 1;
    public float moveSpeed = 2.5f;
    public float delay = 2.0f;
    //


    //
    public float startWaitTime;
    private float waitTime;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public Transform moveSpot;
    GameObject Spot;
    Rigidbody2D rb;
    public float SpotSpeed = 1;

    void Start()
    {
        //
        WJ_SoundManager.instance.BossSound();
        Spot = GameObject.Find("MoveSpot");
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        //
        Invoke("CreateBullet", 0.5f);
        Invoke("CreateMS_Bullet", delay); 
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

    void CreateBullet()
    {
        WJ_SoundManager.instance.BasicMonster();
        Instantiate(Drop_Bullet, ms1.transform.position, Quaternion.identity);
        Invoke("CreateBullet", delay);
    }

    void CreateMS_Bullet()
    {
        WJ_SoundManager.instance.HomingMonster();
        Instantiate(Drop_Ms_Bullet, ms2.transform.position,Quaternion.identity);
        Instantiate(Drop_Ms_Bullet, ms3.transform.position, Quaternion.identity);
        Invoke("CreateMS_Bullet", delay);
    }

    void Update()
    {
    }

    public void ItemDrop()
    {
        float randomValue = Random.Range(0f, 100f);
        if (randomValue <= drop)
        {
            Instantiate(Item, ms1.position, Quaternion.identity);
        }
    }
    public void Damage(int Attack)
    {
        SpawnBoss Spawn = FindObjectOfType<SpawnBoss>();
        HP -= Attack;
        if (HP <= 0)
        {
            Instantiate(BossExplosion, transform.position, Quaternion.identity);
            ItemDrop();
            WJ_SoundManager.instance.ExplosionSound();
            Destroy(gameObject);
            textBossWarning.SetActive(true);
            Instantiate(FinalBoss1, transform.position, Quaternion.identity);       
        }
    }
        
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
