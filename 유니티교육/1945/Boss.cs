using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int HP = 2000;
    public float Speed = 1f;
    public int Delay = 2;
    public Transform ms;
    public Transform ms2;
    public Transform ms3;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public static int RandomPos;

    public GameObject BoomEffect;

    //보스 좌우로 움직임
    float minusX = -1.5f;
    float plusX = 1.5f;
    float direction = 1;

    //총알 쏘는 갯수 변수
    public float oneShoot = 50;

    // Start is called before the first frame update
    void Start()
    {
        //한번만 호출
        Invoke("CreateBullet", Delay);

        //보스가 나타나면 보스 출현 문구 1초 뒤 사라지기
        Invoke("Hide", 1f);

        StartCoroutine("SpreadBullet");

        StartCoroutine("BossMissile");

        StartCoroutine("CircleFire");
    }

    void Hide()
    {
        GameObject.Find("BossWarning").SetActive(false);
    }

    void CreateBullet()
    {
        //Instantiate(bullet2, ms3.position, Quaternion.identity);

        Invoke("CreateBullet", Delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Speed * Time.deltaTime * direction, 0));
        if (transform.position.x >= plusX)
        {
            direction = -1;
        }
        if (transform.position.x <= minusX)
        {
            direction = 1;
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
        Destroy(go, 0.6f);
    }

    IEnumerator SpreadBullet()
    {
        float angle = 360 / oneShoot;
        do
        {
            for (int i = 0; i < oneShoot; i++)
            {
                GameObject obj1;

                obj1 = (GameObject)Instantiate(bullet, ms.transform.position, Quaternion.identity);

                obj1.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.PI * 2 * i / oneShoot),
                    Mathf.Sin(Mathf.PI * i * 2 / oneShoot)));

                obj1.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoot - 90));


                GameObject obj2;

                obj2 = (GameObject)Instantiate(bullet, ms2.transform.position, Quaternion.identity);

                obj2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.PI * 2 * i / oneShoot),
                    Mathf.Sin(Mathf.PI * i * 2 / oneShoot)));

                obj2.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoot - 90));
            }
            yield return new WaitForSeconds(1.5f);

        } while (true);
    }

    IEnumerator BossMissile()
    {
        while (true)
        {
            Instantiate(bullet, ms.position, Quaternion.identity);
            Instantiate(bullet, ms2.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CircleFire()
    {
        float attackRate = 3; //공격주기
        int count = 30;       //발사체 갯수
        float intervalAngle = 360 / count;      //발사체 사이의 각도(중요)
        float weightAngle = 0;      //가중되는 각도(항상 같은 위치로 발사 막기)

        //원 형태로 발사하는 발사체 생성(count 갯수에 따라)
        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                //발사체 생성
                GameObject clone = Instantiate(bullet3, ms3.transform.position, Quaternion.identity);
                //발사체 이동 방향(각도)
                float angle = weightAngle + intervalAngle * i;
                //발사체 이동 방향(벡터)
                //Cos(각도), 라디안 단위의 각도 표현을 위해 PI/180을 곱해야함
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);         //deg2rad나 밑이나 다를거 없음
                //Sin(각도)
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                //발사체 이동 방향 설정
                clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }
            //발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            //attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }


    }
}
