using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static UnityEngine.GraphicsBuffer;

public class LHS_Boss : MonoBehaviour
{
    [Header("이동")]
    [SerializeField] float speed = 1;

    [Header("발사")]     //※ 애니메이션마다 다른 위치에서 나오는?
    [SerializeField] GameObject[] bulletPrefab;
    [SerializeField] Transform[] firePos;
    [SerializeField] float startFire = 5f;
    [SerializeField] float Delay = 1f;

    [Header("data")] //공격력이 필요? -> 모든 적들을 위해?
    [SerializeField] int hp = 100;
    public int attack = 20;
    public int addScore = 5;
    [SerializeField] GameObject uiHP;
    public float maxHp = 100;

    [Header("효과")]
    public GameObject effectfab;
    bool isEffect = false;

    //애니메이션을 위한
    GameObject target;
    Animator anim;
    Vector3 targetDir;

    [Header("보스")]
    public float flag = 1f;
    Vector2 direction;
    public float clampAngle = 14;

    bool bosL1 = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        uiHP = GameObject.FindGameObjectWithTag("HpUp");
        //발사하는 곳 (코드로찾는 방법 - 자식)
        //firePos = transform.Find("FirePos");

        //반복하는 총알발사
        InvokeRepeating("CreateBullet", startFire, Delay);

        //공격
        StartCoroutine(CreateBullet());
        StartCoroutine(CircleFire());
    }

    void Update()
    {
        //Rotation();
        Move();
    }

    void CreateBullet3()
    {
        //총알생성
        Instantiate(bulletPrefab[0], firePos[0].position, Quaternion.identity);
    }
    IEnumerator CreateBullet()
    {
        while (bosL1)
        {
            Instantiate(bulletPrefab[0], firePos[0].position, Quaternion.identity);
            Instantiate(bulletPrefab[0], firePos[0].position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);

            if (hp < 70)
            {
                Instantiate(bulletPrefab[1], firePos[0].position, Quaternion.identity);
            }

            /* if (hp < 50)
             {
                 Instantiate(bullet[2], pos[2].position, Quaternion.identity);
             }*/
        }
    }

    IEnumerator CircleFire()
    {
        float attackRate = 3;//공격주기
        int count = 30; //발사체 생성 갯수
        float intervalAngle = 360 / count; //발사체 상의 각도
        float weightAngle = 0; //가중되는 각도 (항상 같은 위치로 발사하지 않도록 설정)

        //원 형태로 방사하는 발사체 생성(count 개수 만큼)
        while (true)
        {
            for (int i = 0; i < count; ++i) //전의 후의 ++i I++
            {
                //발사체 생성
                GameObject clone = Instantiate(bulletPrefab[2], firePos[0].position, Quaternion.identity);
                //발사체 이동 방향 (각도)
                float angle = weightAngle + intervalAngle * i;
                //발사체 이동 방향 (벡터)
                //Cos(각도), 라디안 단위의 각도 표현을 위해 PI/180을 곱함
                //float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //Sin(각도), 라디안 단위의 각도 표현을 위해 PI/180을 곱함
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                //발사체 이동 방향 설정
                //clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }
            //발사체가 생서되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            //attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate); //3초마다 원형 미사일 발사
        }
    }

    void Move()
    {
        float h = 0;
        float v = 0;

        //아래이동
        if (transform.position.y >= 2)
        {
            v = -1 * speed * Time.deltaTime;
        }

        else
        {
            //좌우이동 (하지말기)
            if (transform.position.x >= 0.75f || transform.position.x <= -0.75f)
            {
                flag *= -1;
            }
            h = flag * speed * Time.deltaTime;
        }

        transform.Translate(h, v, 0);
       /* Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir;*/

        //(보류) 리지드바디로 날라가게 ? // 다른 단계 켜지게?
        /*if (hp < 70)
        {
            //삭제
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }

        if (hp < 50)
        {
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
        }*/
    }

    //제한각주기

    //플레이어 방향으로 바라보기
    void Rotation()
    {
        if (target != null)
        {
            direction = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //제한각잡기 -> 뒤집히는 현상 문제
            //float angleClamped = Mathf.Clamp(angle, -clampAngle, clampAngle);

            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        }
    }

    //플레이어 공격에 따른 데미지
    public void Damage(int attack)
    {
        //공격받으면 깜빡이기
        hp -= attack;

        Score();
        Color color = new Color(0.953f, 0.525f, 0.525f, 1f);
        GetComponent<SpriteRenderer>().color = color;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        Invoke("ColorChange", 0.1f);

        if (hp < 0)
        {
            if(!isEffect)
            {
                isEffect = true;

                DestroyEffect();

                //오디오재생
                LHS_AudioManager.instance.MonsterDie();
                LHS_GameManager.instance.ScoreAdd(addScore);

                // 게임종료
                LHS_GameManager.instance.ClearUI();
                // 공격 멈춘다!
                CancelInvoke("CreateBullet");
                //SceneManager.LoadScene("StartScene");
                // UI 활성화
                //움직임 정지
                Destroy(gameObject);
            }
        }
    }

    void DestroyEffect()
    {
        GameObject go = Instantiate(effectfab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어면 죽기
        if (collision.gameObject.CompareTag("Player"))
        {
            //플레이어 체력 깎기
            collision.gameObject.GetComponent<LHS_Player2Move>().Damage(attack);
            Debug.Log("플레이어 충돌");
        }
    }

    void ColorChange()
    {
        //Color color = new Color(0.878f, 0.878f, 0.878f, 1f);
        GetComponent<SpriteRenderer>().color = Color.white;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Score()
    {
        Debug.Log("보스점수");
        float getHp = hp / maxHp;
        uiHP.gameObject.GetComponent<Image>().fillAmount = getHp;
    }
}
