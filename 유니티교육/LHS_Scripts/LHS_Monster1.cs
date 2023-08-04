using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


//1단계 적
//플레이어를 따라다닌다 -> 일정한 간격을 둔다 (애니메이션)
//총을 발사한다.
public class LHS_Monster1 : MonoBehaviour
{
    [Header("이동")]
    [SerializeField] float speed = 3;
    [SerializeField] float length = 3.0f; //거리
    public bool isMonster2 = false;
    public bool isIdle = false;

    [Header("발사")]     //※ 애니메이션마다 다른 위치에서 나오는?
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePos;
    [SerializeField] float startFire = 5f;
    [SerializeField] float Delay = 1f;

    [Header("data")] //공격력이 필요? -> 모든 적들을 위해?
    [SerializeField] int hp = 100;
    public int attack = 20;
    public int addScore = 5;

    [Header("효과")]
    public GameObject effectfab;

    GameObject target;
    Animator anim;

    Vector3 dir;
    Vector3 targetDir;

    void Start()
    {
        //초기값저장
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        //dir = (target.transform.position - transform.position).normalized;
        //targetDir = Vector3.down;

        //발사하는 곳 (코드로찾는 방법 - 자식)
        firePos = transform.Find("FirePos");

        //반복하는 총알발사
        InvokeRepeating("CreateBullet", startFire, Delay);
    }

    void CreateBullet()
    {
        //총알생성
        Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
    } 

    void Update()
    {
        Animation(); //애니메이션

        Move(); //이동
    }

    void Animation()
    {
        //벡터의 뺄셈 이용한 애니메이션 처리
        //플레이어가 어느 방향쪽에 있는지 체크 이후 애니메이션 바꾸기
        //※ 정면 보고 있는 애니메이션이 짧음 -> 해결
        targetDir = target.transform.position - transform.position;

        if (targetDir.x > 0.5f)
        {
            //+ 오른쪽으로 가야함
            anim.SetBool("Right", true);
        }
        else
        {
            anim.SetBool("Right", false);
        }
        if (targetDir.x < 0.5f)
        {
            anim.SetBool("Left", true);

            if (targetDir.x >= -0.3f) // 정면 애니메이션
            {
                anim.SetBool("Left", false);
            }
        }
        else
        {
            anim.SetBool("Left", false);
        }
    }

    void Move()
    {
        //1단계 적 이동
        if(!isMonster2)
        {
            if (targetDir.y < 0.5f)
            {
                transform.Translate(targetDir.normalized * speed * Time.deltaTime);
            }

            // 플레이어가 위에 있다면 내려가기
            else
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            //총 쏘기 멈추기
            if (transform.position.y <= -2)
            {
                Debug.Log("멈추기");
                CancelInvoke("CreateBullet");
            }

        }
        
        else if(isMonster2 && isIdle)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        //2단계 적 이동
        else
        {
            // 플레이어와 거리를 두고 싶다
            float d = Vector2.Distance(transform.position, target.transform.position);

            if (length <= d)
            {
                transform.Translate(targetDir.normalized * speed * Time.deltaTime);
                /*//이동
                //※ 타겟 위치가 같기 때문에 겹치는 현상 발생 -> 어떻게 해야할까? (Layer충돌처리로 -> 그대신 플레이어랑 못함.. 그럼?)
                //transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);*/
            }
        }
    }

    //플레이어 공격에 따른 데미지
    public void Damage(int attack)
    {
        hp -= attack;

        if(hp < 0)
        {
            DestroyEffect();

            //오디오재생
            LHS_AudioManager.instance.MonsterDie();
            LHS_GameManager.instance.ScoreAdd(addScore);

            Destroy(gameObject);
        }
    }

    //아직 미정
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
}
