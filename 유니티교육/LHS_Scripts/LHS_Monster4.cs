using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LHS_Monster4 : MonoBehaviour
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
        //firePos = transform.Find("FirePos");
    }

    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        //�� ��� ���߱�
       /* if (transform.position.y <= -2)
        {
            Debug.Log("���߱�");
            CancelInvoke("CreateBullet");
        }*/
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

    void MFire()
    {
        firePos.Rotate(0, 0, 45);
        Instantiate(bulletPrefab, transform.position, firePos.rotation);
    }

}
