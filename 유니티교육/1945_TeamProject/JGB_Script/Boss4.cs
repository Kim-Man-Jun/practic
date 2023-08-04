using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Boss4 : MonoBehaviour
{
    public Image BossHp;
    public Transform BulletPos;
    public Transform BulletPos1;
    public Transform BulletPos2;
    public Transform BulletPos3;
    public Transform ItemPos;
    int flag = 1;
    int speed = 4;
    float dTime;
    public int HP = 15000;
    public int nowHP;
    public GameObject Bullet;
    public GameObject BouncyBullet;
    public GameObject HomingBullet;
    public GameObject Explosive;
    public int PatternTime = 0;
    public bool isPattern4 = false;
    public bool isDead;
    public GameObject ItemLifeUp;
    public GameObject HomingAmmo;
    public GameObject BulletTime;
    public GameObject Bg2;
    IEnumerator Pt1;
    IEnumerator Pt2;
    IEnumerator Pt3;
    IEnumerator Pt4;


    void Start()
    {
        Pt1 = Pattern1();
        Pt2 = CircleFire();
        Pt3 = Pattern3();
        Pt4 = Pattern4();
        StartCoroutine(Pt1);
        Invoke("TimeCount", 1);
        InvokeRepeating("ItemDrop", 0,20);
        AudioManager4.instance.StopBg2();
        isDead = false;
        
        HP = 1500;
        nowHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        BossHp.fillAmount = (float)nowHP / (float)HP;
        if(isPattern4 == true) 
        {
            BulletPos.Rotate(0, 0, 3);
            BulletPos3.Rotate(0, 0, -3);
        }


        if (transform.position.x >= 6.5f)
            flag *= -1;
        if (transform.position.x <= -6.5f)
            flag *= -1;

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);


        dTime += Time.deltaTime;
        if (dTime >= 0.5f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            dTime = 0;
        }

    }
    public void ItemDrop()
    {
     
        
        int ItemRan = Random.Range(0, 3);
        //아이템 생성
        if (ItemRan == 0)
        {
            Instantiate(ItemLifeUp, ItemPos.transform.position, Quaternion.identity);
            
        }
        if (ItemRan == 1)
        {
            Instantiate(HomingAmmo, ItemPos.transform.position, Quaternion.identity);
        }
        if (ItemRan == 2)
        {
            Instantiate(BulletTime, ItemPos.transform.position, Quaternion.identity);
        }
       
    }
    void TimeCount()
    {
        
     
        PatternTime++;
        if(PatternTime == 1)
            
        {
            isPattern4 = false;
           
            StartCoroutine(Pt1);
            Invoke("CreateBullet", 0);
           
            
        }
      

        if (PatternTime == 10)
        {
            StopCoroutine(Pt1);
            CancelInvoke("CreateBullet");
            StartCoroutine(Pt2);
        }
        
        if(PatternTime == 30) 
        {
            StopCoroutine(Pt2);
            StartCoroutine(Pt3);
        }
        Invoke("TimeCount", 1);
        if (PatternTime == 40)
        {
            StopCoroutine(Pt3);
            StartCoroutine(Pt4);
            isPattern4 = true;
        }
        if (PatternTime == 50)
        { 
            StopCoroutine (Pt4);
            PatternTime = 0;

        }
      
    }
  
    IEnumerator Pattern1()
    { 
        float attackrate = 2f;
        float angle = 3f;
        while (true)
        {
           


            BulletPos.Rotate(0, 0, 3);
            Instantiate(Bullet, BulletPos1.transform.position, BulletPos1.transform.rotation);
            Instantiate(Bullet, BulletPos2.transform.position, BulletPos2.transform.rotation);
            Instantiate(HomingBullet, BulletPos3.transform.position, Quaternion.identity);
            BulletPos1.Rotate(0, 0, angle);
            BulletPos2.Rotate(0, 0, -angle);


            yield return new WaitForSeconds(attackrate);

          
        }
    }
    IEnumerator CircleFire()
    {
        float attackRate = 5;//공격주기
        int count = 10;    //발사체 생성 갯수
        float intervalAngle = 360 / count;  //발사체 사이의 각도
        float weightAngle = 0; //가중되는 각도 (항상 같은 위치로 발사하지 않도록 설정)


        //원 형태로 방사하는 발사체 생성 (count 개수 만큼)
        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                //발사체 생성
                GameObject clone = Instantiate(BouncyBullet, transform.position, Quaternion.identity);
                //발사체 이동 방향(각도)
                float angle = weightAngle + intervalAngle * i;
                //발사체 이동 방향 (벡터)
                //Cos(각도), 라디안 단위의 각도 표현을 위해 PI/180을 곱함
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //Sin(각도), 라디안 단위의 각도 표현을 위해 PI/180을 곱함
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);
                //발사체 이동 방향 설정
                clone.GetComponent<BouncyBullet4>().Move(new Vector2(x, y));
            }
            //발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 3;

            //attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate); //3초마다 원형 미사일 발사

        }
    }

    IEnumerator Pattern3()
    {
        float atkRate = 1f;
        float p3angle = 180;
        float p3angle2 = 90f;
        float p3angle3 = 270f;

        BulletPos.transform.rotation = Quaternion.identity;
        BulletPos1.transform.rotation = Quaternion.identity;
        BulletPos2.transform.rotation = Quaternion.identity;
        BulletPos3.transform.rotation = Quaternion.identity;
        while (true) 
        {
            Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
            Instantiate(Bullet, BulletPos1.transform.position, BulletPos1.transform.rotation);
            Instantiate(Bullet, BulletPos2.transform.position, BulletPos2.transform.rotation);
            Instantiate(Bullet, BulletPos3.transform.position, BulletPos3.transform.rotation);
            Instantiate(HomingBullet, BulletPos.transform.position, Quaternion.identity);

            BulletPos1.Rotate(0, 0, p3angle);
            BulletPos2.Rotate(0, 0, p3angle2);
            BulletPos3.Rotate(0, 0, p3angle3);
            yield return new WaitForSeconds(atkRate);
        }
       
    }
    IEnumerator Pattern4()
    {
        float attackrate = 0.05f;
       
        while (true)
        {
            


            
            Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
            Instantiate(Bullet, BulletPos3.transform.position, BulletPos3.transform.rotation);
            yield return new WaitForSeconds(attackrate);


        }
    }
    public void Damage(int attack)
    {
        nowHP -= attack;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        AudioManager4.instance.Playhit();
        if (nowHP <= 0)
        {
            AudioManager4.instance.PlaySound();
            Instantiate(Explosive, transform.position, Quaternion.identity);
            TotalGm.instance.isClear4 = true;
            Destroy(gameObject);
           

         
          
        }
    }
  
    void CreateBullet()
    {
        Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
        Invoke("CreateBullet", 0.1f);
    }
}
