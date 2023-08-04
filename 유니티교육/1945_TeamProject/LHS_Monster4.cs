using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LHS_Monster4 : MonoBehaviour
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
        //firePos = transform.Find("FirePos");
    }

    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        //총 쏘기 멈추기
       /* if (transform.position.y <= -2)
        {
            Debug.Log("멈추기");
            CancelInvoke("CreateBullet");
        }*/
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

    void MFire()
    {
        firePos.Rotate(0, 0, 45);
        Instantiate(bulletPrefab, transform.position, firePos.rotation);
    }

}
