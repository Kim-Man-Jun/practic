using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static UnityEngine.GraphicsBuffer;

public class LHS_Boss : MonoBehaviour
{
    [Header("�̵�")]
    [SerializeField] float speed = 1;

    [Header("�߻�")]     //�� �ִϸ��̼Ǹ��� �ٸ� ��ġ���� ������?
    [SerializeField] GameObject[] bulletPrefab;
    [SerializeField] Transform[] firePos;
    [SerializeField] float startFire = 5f;
    [SerializeField] float Delay = 1f;

    [Header("data")] //���ݷ��� �ʿ�? -> ��� ������ ����?
    [SerializeField] int hp = 100;
    public int attack = 20;
    public int addScore = 5;
    [SerializeField] GameObject uiHP;
    public float maxHp = 100;

    [Header("ȿ��")]
    public GameObject effectfab;
    bool isEffect = false;

    //�ִϸ��̼��� ����
    GameObject target;
    Animator anim;
    Vector3 targetDir;

    [Header("����")]
    public float flag = 1f;
    Vector2 direction;
    public float clampAngle = 14;

    bool bosL1 = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        uiHP = GameObject.FindGameObjectWithTag("HpUp");
        //�߻��ϴ� �� (�ڵ��ã�� ��� - �ڽ�)
        //firePos = transform.Find("FirePos");

        //�ݺ��ϴ� �Ѿ˹߻�
        InvokeRepeating("CreateBullet", startFire, Delay);

        //����
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
        //�Ѿ˻���
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
        float attackRate = 3;//�����ֱ�
        int count = 30; //�߻�ü ���� ����
        float intervalAngle = 360 / count; //�߻�ü ���� ����
        float weightAngle = 0; //���ߵǴ� ���� (�׻� ���� ��ġ�� �߻����� �ʵ��� ����)

        //�� ���·� ����ϴ� �߻�ü ����(count ���� ��ŭ)
        while (true)
        {
            for (int i = 0; i < count; ++i) //���� ���� ++i I++
            {
                //�߻�ü ����
                GameObject clone = Instantiate(bulletPrefab[2], firePos[0].position, Quaternion.identity);
                //�߻�ü �̵� ���� (����)
                float angle = weightAngle + intervalAngle * i;
                //�߻�ü �̵� ���� (����)
                //Cos(����), ���� ������ ���� ǥ���� ���� PI/180�� ����
                //float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //Sin(����), ���� ������ ���� ǥ���� ���� PI/180�� ����
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                //�߻�ü �̵� ���� ����
                //clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }
            //�߻�ü�� �����Ǵ� ���� ���� ������ ���� ����
            weightAngle += 1;

            //attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate); //3�ʸ��� ���� �̻��� �߻�
        }
    }

    void Move()
    {
        float h = 0;
        float v = 0;

        //�Ʒ��̵�
        if (transform.position.y >= 2)
        {
            v = -1 * speed * Time.deltaTime;
        }

        else
        {
            //�¿��̵� (��������)
            if (transform.position.x >= 0.75f || transform.position.x <= -0.75f)
            {
                flag *= -1;
            }
            h = flag * speed * Time.deltaTime;
        }

        transform.Translate(h, v, 0);
       /* Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir;*/

        //(����) ������ٵ�� ���󰡰� ? // �ٸ� �ܰ� ������?
        /*if (hp < 70)
        {
            //����
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }

        if (hp < 50)
        {
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
        }*/
    }

    //���Ѱ��ֱ�

    //�÷��̾� �������� �ٶ󺸱�
    void Rotation()
    {
        if (target != null)
        {
            direction = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //���Ѱ���� -> �������� ���� ����
            //float angleClamped = Mathf.Clamp(angle, -clampAngle, clampAngle);

            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        }
    }

    //�÷��̾� ���ݿ� ���� ������
    public void Damage(int attack)
    {
        //���ݹ����� �����̱�
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

                //��������
                LHS_AudioManager.instance.MonsterDie();
                LHS_GameManager.instance.ScoreAdd(addScore);

                // ��������
                LHS_GameManager.instance.ClearUI();
                // ���� �����!
                CancelInvoke("CreateBullet");
                //SceneManager.LoadScene("StartScene");
                // UI Ȱ��ȭ
                //������ ����
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
        //�÷��̾�� �ױ�
        if (collision.gameObject.CompareTag("Player"))
        {
            //�÷��̾� ü�� ���
            collision.gameObject.GetComponent<LHS_Player2Move>().Damage(attack);
            Debug.Log("�÷��̾� �浹");
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
        Debug.Log("��������");
        float getHp = hp / maxHp;
        uiHP.gameObject.GetComponent<Image>().fillAmount = getHp;
    }
}
