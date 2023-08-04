using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LHS_Monster3 : MonoBehaviour
{
    [Header("�̵�")]
    [SerializeField] float speed = 1;

    [Header("�߻�")]     //�� �ִϸ��̼Ǹ��� �ٸ� ��ġ���� ������?
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePos;
    [SerializeField] float startFire = 5f;
    [SerializeField] float Delay = 1f;

    [Header("data")] //���ݷ��� �ʿ�? -> ��� ������ ����?
    [SerializeField] int hp = 100;
    public int attack = 20;
    public int addScore = 5;

    [Header("ȿ��")]
    public GameObject effectfab;
    bool isEffect = false;

    //�ִϸ��̼��� ����
    GameObject target;
    Animator anim;
    Vector3 targetDir;


    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");

        //�߻��ϴ� �� (�ڵ��ã�� ��� - �ڽ�)
        firePos = transform.Find("FirePos");

        //�ݺ��ϴ� �Ѿ˹߻�
        InvokeRepeating("CreateBullet", startFire, Delay);
    }

    void CreateBullet()
    {
        //�Ѿ˻���
        Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
    }


    void Update()
    {
        Animation();

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        //�� ��� ���߱�
       /* if (transform.position.y <= -2)
        {
            Debug.Log("���߱�");
            CancelInvoke("CreateBullet");
        }*/
    }

    void Animation()
    {
        //������ ���� �̿��� �ִϸ��̼� ó��
        //�÷��̾ ��� �����ʿ� �ִ��� üũ ���� �ִϸ��̼� �ٲٱ�
        //�� ���� ���� �ִ� �ִϸ��̼��� ª�� -> �ذ�
        targetDir = target.transform.position - transform.position;

        if (targetDir.x > 0.5f)
        {
            //+ ���������� ������
            anim.SetBool("Right", true);
        }
        else
        {
            anim.SetBool("Right", false);
        }
        if (targetDir.x < 0.5f)
        {
            anim.SetBool("Left", true);

            if (targetDir.x >= -0.3f) // ���� �ִϸ��̼�
            {
                anim.SetBool("Left", false);
            }
        }
        else
        {
            anim.SetBool("Left", false);
        }
    }

    //�÷��̾� ���ݿ� ���� ������
    public void Damage(int attack)
    {
        hp -= attack;

        if (hp < 0)
        {
            if(!isEffect)
            {
                isEffect = true;

                DestroyEffect();

                //��������
                LHS_AudioManager.instance.MonsterDie();
                LHS_GameManager.instance.ScoreAdd(addScore);

                anim.SetBool("Die", true);
                //�Ѿ˹߻� ����
                CancelInvoke("CreateBullet");
                //�浹����
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }

    //ȭ�� ������ ������ ����
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
        //�÷��̾�� �ױ�
        if (collision.gameObject.CompareTag("Player"))
        {
            //�÷��̾� ü�� ���
            collision.gameObject.GetComponent<LHS_Player2Move>().Damage(attack);
            Debug.Log("�÷��̾� �浹");
        }
    }
}
