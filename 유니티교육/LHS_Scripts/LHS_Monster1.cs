using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


//1�ܰ� ��
//�÷��̾ ����ٴѴ� -> ������ ������ �д� (�ִϸ��̼�)
//���� �߻��Ѵ�.
public class LHS_Monster1 : MonoBehaviour
{
    [Header("�̵�")]
    [SerializeField] float speed = 3;
    [SerializeField] float length = 3.0f; //�Ÿ�
    public bool isMonster2 = false;
    public bool isIdle = false;

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

    GameObject target;
    Animator anim;

    Vector3 dir;
    Vector3 targetDir;

    void Start()
    {
        //�ʱⰪ����
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        //dir = (target.transform.position - transform.position).normalized;
        //targetDir = Vector3.down;

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
        Animation(); //�ִϸ��̼�

        Move(); //�̵�
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

    void Move()
    {
        //1�ܰ� �� �̵�
        if(!isMonster2)
        {
            if (targetDir.y < 0.5f)
            {
                transform.Translate(targetDir.normalized * speed * Time.deltaTime);
            }

            // �÷��̾ ���� �ִٸ� ��������
            else
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            //�� ��� ���߱�
            if (transform.position.y <= -2)
            {
                Debug.Log("���߱�");
                CancelInvoke("CreateBullet");
            }

        }
        
        else if(isMonster2 && isIdle)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        //2�ܰ� �� �̵�
        else
        {
            // �÷��̾�� �Ÿ��� �ΰ� �ʹ�
            float d = Vector2.Distance(transform.position, target.transform.position);

            if (length <= d)
            {
                transform.Translate(targetDir.normalized * speed * Time.deltaTime);
                /*//�̵�
                //�� Ÿ�� ��ġ�� ���� ������ ��ġ�� ���� �߻� -> ��� �ؾ��ұ�? (Layer�浹ó���� -> �״�� �÷��̾�� ����.. �׷�?)
                //transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);*/
            }
        }
    }

    //�÷��̾� ���ݿ� ���� ������
    public void Damage(int attack)
    {
        hp -= attack;

        if(hp < 0)
        {
            DestroyEffect();

            //��������
            LHS_AudioManager.instance.MonsterDie();
            LHS_GameManager.instance.ScoreAdd(addScore);

            Destroy(gameObject);
        }
    }

    //���� ����
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
