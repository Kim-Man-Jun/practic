using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LHS_Monster3 : MonoBehaviour
{
    [Header("이동")]
    [SerializeField] float speed = 1;

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
    bool isEffect = false;

    //애니메이션을 위한
    GameObject target;
    Animator anim;
    Vector3 targetDir;


    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");

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
        Animation();

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        //총 쏘기 멈추기
       /* if (transform.position.y <= -2)
        {
            Debug.Log("멈추기");
            CancelInvoke("CreateBullet");
        }*/
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

    //플레이어 공격에 따른 데미지
    public void Damage(int attack)
    {
        hp -= attack;

        if (hp < 0)
        {
            if(!isEffect)
            {
                isEffect = true;

                DestroyEffect();

                //오디오재생
                LHS_AudioManager.instance.MonsterDie();
                LHS_GameManager.instance.ScoreAdd(addScore);

                anim.SetBool("Die", true);
                //총알발사 멈춤
                CancelInvoke("CreateBullet");
                //충돌끄기
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }

    //화면 밖으로 나가면 삭제
    void OnBecameInvisible()
    {
        Destroy(gameObject);
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
}
