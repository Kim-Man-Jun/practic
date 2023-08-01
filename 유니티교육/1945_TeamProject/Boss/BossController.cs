using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

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

    //페이즈 진입시 뿌려주는 회복템
    public GameObject HpItem;
    int Phase = 0;

    //보스 등장 관련 변수들
    public static int BossAppear = 0;
    [SerializeField] GameObject textBossWarning;
    [SerializeField] GameObject BossMaxHpBar;
    [SerializeField] GameObject Boss;

    public static bool BossClear = false;

    //사운드 관련
    AudioSource BS;
    AudioSource Oneshot;
    public AudioClip Patern1;
    public AudioClip Patern2;
    public AudioClip Patern3;
    public AudioClip Patern4;

    public AudioClip StageClaer;
    public AudioClip BossBoom;

    private void Awake()
    {
        textBossWarning.SetActive(false);
        BossMaxHpBar.SetActive(false);
        Boss.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //보스 체력 설정
        BossNowHp = BossMaxHp;
        BS = GetComponent<AudioSource>();
        Oneshot = GetComponent<AudioSource>();

        BS.Play();
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

                Oneshot.PlayOneShot(Patern1);
            }

            //2번 pos 유도미사일 발사
            curTime2 += Time.deltaTime;

            if (curTime2 >= 0.9f)
            {
                BossHoming();
                curTime2 = 0;

                Oneshot.PlayOneShot(Patern1);
            }
        }

        //부채꼴로 쏘는 탄막
        if (BossNowHp <= 18000 && BossNowHp > 12000)
        {
            //페이즈 구분
            if (Phase == 0)
            {
                StartCoroutine("HpItemDrop");
            }

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

                        Destroy(go, 5f);

                        Bullets.Add(go.transform);

                        go.transform.rotation = Quaternion.Euler(0, 0, i);
                    }
                }
                curTime = 0;
                Oneshot.PlayOneShot(Patern2);
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

                        Destroy(go, 5f);

                        Bullets.Add(go.transform);

                        go.transform.rotation = Quaternion.Euler(0, 0, i);
                    }
                }
                curTime2 = 0;
                Oneshot.PlayOneShot(Patern2);
            }

        }

        //360도 탄막과 드문드문 쏘는 호밍탄막
        if (BossNowHp <= 12000 && BossNowHp > 6000)
        {
            //페이즈 구분
            if (Phase == 1)
            {
                StartCoroutine("HpItemDrop");
            }

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

                    Destroy(go, 5f);

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
                Oneshot.PlayOneShot(Patern1);
            }
        }

        //360도 쏜 다음 유도하는 탄막
        if (BossNowHp <= 6000)
        {
            //페이즈 구분
            if (Phase == 2)
            {
                StartCoroutine("HpItemDrop");
            }
            curTime += Time.deltaTime;

            if (curTime >= 1f)
            {
                //총알 오브젝트 수록
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 10)
                {
                    //생성
                    GameObject go = Instantiate(Bullet1);
                    //발사 위치는 firepos3
                    go.transform.position = FirePos3.position;

                    Destroy(go, 5f);

                    Bullets.Add(go.transform);
                    //z에 값이 변해야 회전하니 z에 i를 대입
                    go.transform.rotation = Quaternion.Euler(0, 0, i);
                }

                StartCoroutine(BulletToTarget(Bullets));
                curTime = 0;

                Oneshot.PlayOneShot(Patern4);
            }

            curTime2 += Time.deltaTime;

            if (curTime2 >= 0.8f)
            {
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 20)
                {
                    GameObject go = Instantiate(Bullet1);

                    go.transform.position = FirePos4.position;

                    Destroy(go, 5f);

                    Bullets.Add(go.transform);

                    go.transform.rotation = Quaternion.Euler(0, 0, i);
                }

                StartCoroutine(BulletToTarget(Bullets));
                curTime2 = 0;

                Oneshot.PlayOneShot(Patern4);
            }
        }
    }

    //일정 체력 이하면 회복템 하나 떨굼 수정 필요
    IEnumerator HpItemDrop()
    {
        if (HpItem != null)
        {
            Instantiate(HpItem, FirePos3.transform.position, Quaternion.identity);
        }
        Phase++;
        yield return null;
    }

    //유도미사일 발사
    void BossHoming()
    {
        Instantiate(Bullet2, FirePos1.position, Quaternion.identity);
    }

    //플레이어 유도탄 코루틴
    IEnumerator BulletToTarget(IList<Transform> objects)
    {
        yield return new WaitForSeconds(0.6f);

        for (int i = 0; i < objects.Count; i++)
        {
            //현재 총알의 위치에서 플레이어 위치의 벡터값을 구함
            Vector3 targetDirection = PlayerPos.transform.position - objects[i].position;
            //x,y 값을 조합하여 z방향 값으로 변형 후 ~도 단위로 변환
            float angle = Mathf.Atan2(targetDirection.x, -targetDirection.y) * Mathf.Rad2Deg;
            //오브젝트 이동
            objects[i].rotation = Quaternion.Euler(0, 0, angle);
        }

        objects.Clear();
    }


    //보스가 데미지를 입을 경우 실행되는 메서드
    public void Damage(int attack)
    {
        BossNowHp -= attack;

        //보스가 맞을때마다 코루틴 실행
        StartCoroutine("BossDamage");

        //보스 체력이 0일때
        if (BossNowHp <= 0)
        {
            BS.Stop();

            BossClear = true;
            //보스 체력바가 남을걸 대비해 아예 없어버림
            BossNowHpBar.fillAmount = 0;

            //보스의 현재 스크립트를 찾아서
            BossController bossController = GetComponent<BossController>();
            //없애버리면서 총알 발사 막기
            Destroy(bossController);

            //노가다1번
            GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
            
            GameObject go1 = Instantiate(BoomEffect, new Vector3(transform.position.x + 1, transform.position.y + 1.3f),
                Quaternion.identity);
            GameObject go2 = Instantiate(BoomEffect, new Vector3(transform.position.x - 1.1f, transform.position.y - 1.2f),
                Quaternion.identity);
            GameObject go3 = Instantiate(BoomEffect, new Vector3(transform.position.x - 1.6f, transform.position.y + 1.7f),
                Quaternion.identity);
            GameObject go4 = Instantiate(BoomEffect, new Vector3(transform.position.x + 1.2f, transform.position.y - 1.6f),
                Quaternion.identity);
            GameObject go5 = Instantiate(BoomEffect, new Vector3(transform.position.x - 1.4f, transform.position.y - 1.5f),
                Quaternion.identity);
            GameObject go6 = Instantiate(BoomEffect, new Vector3(transform.position.x - 2f, transform.position.y - 1.4f),
                Quaternion.identity);

            Oneshot.PlayOneShot(BossBoom);

            //노가다 2번
            Destroy(go, 3f);
            Destroy(go1, 3f);
            Destroy(go2, 3f);
            Destroy(go3, 3f);
            Destroy(go4, 3f);
            Destroy(go5, 3f);
            Destroy(go6, 3f);
            Destroy(gameObject, 3.2f);

            Oneshot.PlayOneShot(StageClaer);
        }
    }

    IEnumerator BossDamage()
    {
        //현재 오브젝트에 달린 자식 오브젝트의 스프라이트 렌더러를 가져와서
        //피격시 빨간색으로 점멸하는 효과
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.15f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.15f);
    }
}
