using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    //보스 체력 관련채
    public static float BossNowHp;
    public float BossMaxHp = 20000;
    public Image BossNowHpBar;

    //보스 탄막 관련
    public GameObject Bullet1;
    public GameObject Bullet2;

    //보스 발사구 관련
    public Transform FirePos1 = null;
    public Transform FirePos2 = null;
    public Transform FirePos3 = null;
    public Transform FirePos4 = null;

    //보스 터지는 이펙트
    public GameObject BoomEffect;

    //보스가 노리는 대상
    public Transform PlayerPos;

    //탄막 쿨타임 주기
    float curTime = 0;
    float curTime2 = 0;
    float curTime3 = 0;

    float Delay = 0;

    public float BulletSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        BossNowHp = BossMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //보스 체력 관련
        BossNowHpBar.fillAmount = (float)BossNowHp / (float)BossMaxHp;

        //맵 이동제한 걸기
        if (transform.position.x <= -1.9f)
        {
            transform.position = new Vector3(-1.9f, transform.position.y, 0);
        }
        if (transform.position.x >= 1.9f)
        {
            transform.position = new Vector3(1.9f, transform.position.y, 0);
        }

        //일반적 호밍 탄막
        if (BossNowHp <= 20000 && BossNowHp > 18000)
        {
            //1번 pos 유도미사일 발사
            curTime += Time.deltaTime;

            if (curTime >= 0.7f)
            {
                BossHoming();
                curTime = 0;
            }

            //2번 pos 유도미사일 발사
            curTime2 += Time.deltaTime;

            if (curTime2 >= 0.9f)
            {
                BossHoming();
                curTime2 = 0;
            }
        }

        //부채꼴로 쏘는 탄막
        if (BossNowHp <= 18000 && BossNowHp > 12000)
        {
            //FirePos 3번 발사 360도
            curTime += Time.deltaTime;

            if (curTime >= 0.5f)
            {
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 20)
                {
                    if ((i >= 340 && i < 360) || (i >= 0 && i <= 40))
                    {
                        GameObject go = Instantiate(Bullet1);

                        go.transform.position = FirePos3.position;

                        Destroy(go, 2f);

                        Bullets.Add(go.transform);

                        go.transform.rotation = Quaternion.Euler(0, 0, i);
                    }
                }
                curTime = 0;
            }

            //FirePos 4번 발사 360도
            curTime2 += Time.deltaTime;

            if (curTime2 >= 0.5f)
            {
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 20)
                {
                    if ((i >= 340 && i < 360) || (i >= 0 && i <= 40))
                    {
                        GameObject go = Instantiate(Bullet1);

                        go.transform.position = FirePos4.position;

                        Destroy(go, 2f);

                        Bullets.Add(go.transform);

                        go.transform.rotation = Quaternion.Euler(0, 0, i);
                    }
                }
                curTime2 = 0;
            }
        }

        //360도 탄막과 드문드문 쏘는 호밍탄막
        if (BossNowHp <= 12000 && BossNowHp > 6000)
        {
            //FirePos 3번 발사 스핀으로
            FirePos3.transform.Rotate(Vector3.forward * 300 * Time.deltaTime);

            curTime += Time.deltaTime;

            if (curTime >= 0.05f)
            {
                GameObject go = Instantiate(Bullet1);
                go.transform.position = FirePos3.position;
                go.transform.rotation = FirePos3.rotation;
                curTime = 0;
            }

            //FirePos 4번 발사 360도
            curTime2 += Time.deltaTime;

            if (curTime2 >= 0.7f)
            {
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 10)
                {
                    GameObject go = Instantiate(Bullet1);

                    go.transform.position = FirePos4.position;

                    Destroy(go, 2f);

                    Bullets.Add(go.transform);

                    go.transform.rotation = Quaternion.Euler(0, 0, i);
                }
                curTime2 = 0;
            }

            //FirePos 1번 발사 강한 호밍 미사일
            curTime3 += Time.deltaTime;

            if (curTime3 >= 2.5f)
            {
                BossHoming();
                curTime3 = 0;
            }
        }

        //360도 쏜 다음 유도하는 탄막으로(유도가 안됨)
        if (BossNowHp <= 6000)
        {
            curTime += Time.deltaTime;

            print(curTime);

            if (curTime >= 2f)
            {
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 13)
                {
                    GameObject go = Instantiate(Bullet1);

                    go.transform.position = FirePos3.position;

                    Destroy(go, 2f);

                    Bullets.Add(go.transform);

                    go.transform.rotation = Quaternion.Euler(0, 0, i);
                }

                StartCoroutine(BulletToTarget(Bullets));
                curTime = 0;
            }
        }
    }

    //유도미사일 발사
    void BossHoming()
    {
        Instantiate(Bullet2, FirePos1.position, Quaternion.identity);
    }

    IEnumerator BulletToTarget(IList<Transform> objects)
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("!!!!!!!");
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.Translate(Vector3.zero);

            Vector2 dir = PlayerPos.transform.position
                - objects[i].transform.position;

            Vector2 dirNo = dir.normalized;

            objects[i].transform.Translate(dirNo * BulletSpeed * Time.deltaTime);
        }

        objects.Clear();
    }


    public void Damage(int attack)
    {
        BossNowHp -= attack;

        if (BossNowHp <= 0)
        {
            BossNowHpBar.fillAmount = 0;
            Destroy(gameObject);
        }
    }       //공격 받을때 이벤트 처리

    private void OnDestroy()
    {
        GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Destroy(go, 0.5f);
    }               //오브젝트가 터질때 처리
}
