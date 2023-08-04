using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LHS_Player2Bullet : MonoBehaviour
{
    [Header("무기속성")]
    public float speed = 5f;
    public int Attack = 10;

    [Header("부메랑")]
    //부메랑
    public bool isReturning = false;
    //나가고 있는지 체크
    public bool isExiting = false;
    //두번째 종알 나갈건지 체크
    public bool isbullet2 = false;
    //이동할 거리
    public float moveDistance = 5f;

    // 다시 돌아올 타겟 (필요 없을 지도)
    GameObject player;
    GameObject target;

    Vector2 initialPosition; //초기 위치 저장
    Vector2 currentPos; //현재 위치 저장

    //가장 가까운 몬스터 찾기 // 굳이 ?
    public string monsterTag = "Monster";

    //가까운적 (1,2)
    Transform closestEnemy1;
    Transform closestEnemy2;

    //타겟 위치
    Vector2 targetPosition1;
    Vector2 targetPosition2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //적 찾기
        //TargetTest();

        //랜덤값으로 (보류)
        //MoveRandomDirection();
    }

    private void Update()
    {
        //플레이어 위치
        initialPosition = player.transform.position;

        //현재 내 위치
        currentPos = transform.position;

        //※돌아오기전에는 한번 더 발사 못하게
        if (Input.GetKeyDown(KeyCode.Z) && !isExiting)
        {
            isExiting = true;
            isReturning = true;

            //가장 가까운 적 찾기
            FindMonster();

            //충돌처리 키기
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        //부메랑
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
            // 속도를 높여 초기 위치(보류)
            //float step = speed * returnSpeedMultiplier * Time.deltaTime;
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            if (currentPos == initialPosition)
            {
                isExiting = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;

                //랜덤 값 다시 지정
                /*Vector3 randomDrection = Random.insideUnitSphere.normalized;
                targetPosition = new Vector3(transform.position.x, transform.position.y, 0) + randomDrection * moveDistance;*/
            }
        }
    }

    //몬스터 찾아서 방향 정하기
    void TargetTest()
    {
        target = GameObject.FindGameObjectWithTag("Monster");

        if(target != null)
        {
            //몬스터 방향
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
            //방향을 정해주면 되는 거 아닌가? //일정한 길이로
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

    //가장 가까운 적 찾기 기능
    Transform FindClosestMonsterWithTag(string tag, Transform excludedEnemy = null)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        Transform closestEnemy = null;
        float closetDistance = Mathf.Infinity;
        Vector2 playerPosition = player.transform.position;

        foreach(GameObject enemy in enemies)
        {
            if (enemy.transform == excludedEnemy) continue; // 이미 찾은 적이면 건너 뜁니다.

            float distance = Vector2.Distance(enemy.transform.position, playerPosition);
            if(distance < closetDistance)
            {
                closetDistance = distance;
                closestEnemy = enemy.transform;
            }
        }
        return closestEnemy;
    }

    //없으면 랜덤 방향!
    void MoveRandomDirection()
    {
        //※짧은건 왜 그런지 오류 찾아야함 //다른거랑 겹치기 싫음
        //랜덤한 방향을 생성
        //Vector2 randomDrection = Random.insideUnitSphere.normalized;
        Vector2 randomDrection = Random.insideUnitSphere * 2; 
        //적을 찾아서 발사 적 방향으로?

        //randomDrection.y = 0f; //y축 이동하지 않도록 설정(수평이동?) -> 난 다 이동하고 싶다면!
        targetPosition1 = new Vector2(transform.position.x, transform.position.y) + randomDrection.normalized * moveDistance;
        targetPosition2 = new Vector2(transform.position.x, transform.position.y) + randomDrection.normalized * moveDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //나중에 상속으로 관리한다면?
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

    //플레이어 애니메이션 확인
    void AnimationCheck()
    {
        Animator anim = player.GetComponent<Animator>();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Right"))
        {
            //Debug.Log("오른쪽");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Up"))
        {
            //Debug.Log("가운데");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Left"))
        {
            //Debug.Log("왼쪽");
        }
    }
}
