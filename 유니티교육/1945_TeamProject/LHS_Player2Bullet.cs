using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LHS_Player2Bullet : MonoBehaviour
{
    [Header("����Ӽ�")]
    public float speed = 5f;
    public int Attack = 10;

    [Header("�θ޶�")]
    //�θ޶�
    public bool isReturning = false;
    //������ �ִ��� üũ
    public bool isExiting = false;
    //�ι�° ���� �������� üũ
    public bool isbullet2 = false;
    //�̵��� �Ÿ�
    public float moveDistance = 5f;

    // �ٽ� ���ƿ� Ÿ�� (�ʿ� ���� ����)
    GameObject player;
    GameObject target;

    Vector2 initialPosition; //�ʱ� ��ġ ����
    Vector2 currentPos; //���� ��ġ ����

    //���� ����� ���� ã�� // ���� ?
    public string monsterTag = "Monster";

    //������� (1,2)
    Transform closestEnemy1;
    Transform closestEnemy2;

    //Ÿ�� ��ġ
    Vector2 targetPosition1;
    Vector2 targetPosition2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //�� ã��
        //TargetTest();

        //���������� (����)
        //MoveRandomDirection();
    }

    private void Update()
    {
        //�÷��̾� ��ġ
        initialPosition = player.transform.position;

        //���� �� ��ġ
        currentPos = transform.position;

        //�ص��ƿ��������� �ѹ� �� �߻� ���ϰ�
        if (Input.GetKeyDown(KeyCode.Z) && !isExiting)
        {
            isExiting = true;
            isReturning = true;

            //���� ����� �� ã��
            FindMonster();

            //�浹ó�� Ű��
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        //�θ޶�
        if (isReturning)
        {
            float step = speed * Time.deltaTime;

            if(!isbullet2)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition1, step);

                float distance = Vector3.Distance(currentPos, targetPosition1);

                if (distance <= 0.5f)
                {
                    isReturning = false;
                }
            }

            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition2, step);

                /*if (currentPos == targetPosition2)
                {
                    isReturning = false;
                }*/

                float distance = Vector3.Distance(currentPos, targetPosition2);

                if (distance <= 0.5f)
                {
                    isReturning = false;
                }
            }
        }

        else
        {
            // �ӵ��� ���� �ʱ� ��ġ(����)
            //float step = speed * returnSpeedMultiplier * Time.deltaTime;
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            if (currentPos == initialPosition)
            {
                isExiting = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;

                //���� �� �ٽ� ����
                /*Vector3 randomDrection = Random.insideUnitSphere.normalized;
                targetPosition = new Vector3(transform.position.x, transform.position.y, 0) + randomDrection * moveDistance;*/
            }
        }
    }

    //���� ã�Ƽ� ���� ���ϱ�
    void TargetTest()
    {
        target = GameObject.FindGameObjectWithTag("Monster");

        if(target != null)
        {
            //���� ����
            Vector2 dir = target.transform.position - transform.position;
            //targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);

            targetPosition1 = new Vector2(transform.position.x, transform.position.y) + dir.normalized * moveDistance;
        }
    }

    void FindMonster()
    {
        closestEnemy1 = FindClosestMonsterWithTag(monsterTag);
        if (closestEnemy1 != null)
        {
            //������ �����ָ� �Ǵ� �� �ƴѰ�? //������ ���̷�
            Vector2 dir1 = closestEnemy1.position - transform.position;
            targetPosition1 = new Vector2(transform.position.x, transform.position.y) + dir1.normalized * moveDistance;
            //targetPosition1 = new Vector2(closestEnemy1.position.x, closestEnemy1.position.y);

            closestEnemy2 = FindClosestMonsterWithTag(monsterTag, closestEnemy1);
            if (closestEnemy2 != null)
            {
                Vector2 dir2 = closestEnemy2.position - transform.position;
                targetPosition2 = new Vector2(transform.position.x, transform.position.y) + dir2.normalized * moveDistance;
                //targetPosition2 = new Vector2(closestEnemy2.position.x, closestEnemy2.position.y);
            }
        }

        else
        {
            MoveRandomDirection();
        }
    }

    //���� ����� �� ã�� ���
    Transform FindClosestMonsterWithTag(string tag, Transform excludedEnemy = null)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        Transform closestEnemy = null;
        float closetDistance = Mathf.Infinity;
        Vector2 playerPosition = player.transform.position;

        foreach(GameObject enemy in enemies)
        {
            if (enemy.transform == excludedEnemy) continue; // �̹� ã�� ���̸� �ǳ� �ݴϴ�.

            float distance = Vector2.Distance(enemy.transform.position, playerPosition);
            if(distance < closetDistance)
            {
                closetDistance = distance;
                closestEnemy = enemy.transform;
            }
        }
        return closestEnemy;
    }

    //������ ���� ����!
    void MoveRandomDirection()
    {
        //��ª���� �� �׷��� ���� ã�ƾ��� //�ٸ��Ŷ� ��ġ�� ����
        //������ ������ ����
        //Vector2 randomDrection = Random.insideUnitSphere.normalized;
        Vector2 randomDrection = Random.insideUnitSphere * 2; 
        //���� ã�Ƽ� �߻� �� ��������?

        //randomDrection.y = 0f; //y�� �̵����� �ʵ��� ����(�����̵�?) -> �� �� �̵��ϰ� �ʹٸ�!
        targetPosition1 = new Vector2(transform.position.x, transform.position.y) + randomDrection.normalized * moveDistance;
        targetPosition2 = new Vector2(transform.position.x, transform.position.y) + randomDrection.normalized * moveDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���߿� ������� �����Ѵٸ�?
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster1"))
        {
            collision.gameObject.GetComponent<LHS_Monster1>().Damage(Attack);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Monster2"))
        {
            collision.gameObject.GetComponent<LHS_Monster2>().Damage(Attack);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster3"))
        {
            collision.gameObject.GetComponent<LHS_Monster3>().Damage(Attack);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster4"))
        {
            collision.gameObject.GetComponent<LHS_Monster4>().Damage(Attack);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            collision.gameObject.GetComponent<LHS_Boss>().Damage(Attack);
        }
    }

    //�÷��̾� �ִϸ��̼� Ȯ��
    void AnimationCheck()
    {
        Animator anim = player.GetComponent<Animator>();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Right"))
        {
            //Debug.Log("������");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Up"))
        {
            //Debug.Log("���");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Left"))
        {
            //Debug.Log("����");
        }
    }
}
