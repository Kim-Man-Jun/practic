using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Attack,
        AttackIdle,
        Dead
    }

    //idle을 기본 상태로 지정
    public State currentState = State.Idle;

    Vector3 curTargetPos;                           //마우스 클릭 지점, 목적지의 좌표
    public float rotAnglePerSecond = 360f;          //1초에 플레이어의 방향을 수치만큼 회전
    public float moveSpeed = 2f;                    //초당 수치의 속도로 이동

    float AttackDelay = 2f;         //공격 후 지연시간
    float AttackTimer = 0f;         //공격 후 지연시간 계산용
    float AttackDistance = 1.5f;    //공격 거리, 적과의 거리
    float ChaseDistance = 2.5f;     //다시 추적을 시작하기 위한 거리

    GameObject curEnemy;

    PlayerAni myAni;
    PlayerParams myParams;
    EnemyParams curEnemyParams;

    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<PlayerAni>();
        myParams = GetComponent<PlayerParams>();
        
        ChangeState(State.Idle, PlayerAni.ANI_IDLE);

        myParams.InitParams();
        myParams.deadEvent.AddListener(ChangeToPlayerDead);
    }

    public void ChangeToPlayerDead()
    {
        print("player was Dead");
        ChangeState(State.Dead, PlayerAni.ANI_DIE);

        UIMananger.instance.ShowGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    public void CurrentEnemyDead()
    {
        ChangeState(State.Idle, PlayerAni.ANI_IDLE);
        print("enemy was Killed");

        curEnemy = null;
    }

    public void AttackCalculate()
    {
        if(curEnemy == null)
        {
            return;
        }

        curEnemy.GetComponent<EnemyFSM>().ShowHitEffect();

        int attackPower = myParams.GetRandomAttack();
        curEnemyParams.SetEnemyAttack(attackPower);

        SoundManager.instance.PlayHitSound();
    }

    public void AttackEnemy(GameObject enemy)
    {
        if (curEnemy != null && curEnemy == enemy)
        {
            return;
        }

        //적의 파라미터 변수에 저장
        curEnemyParams = enemy.GetComponent<EnemyParams>();
        
        if(curEnemyParams.isDead == false)
        {
            curEnemy = enemy;
            curTargetPos = curEnemy.transform.position;
            GameManager.instance.ChangeCurrentTarget(curEnemy);
            ChangeState(State.Move, PlayerAni.ANI_WALK);
        }
        else
        {
            curEnemyParams = null;
        }
    }

    void ChangeState(State newState, int aniNumber)
    {
        if (currentState == newState)
        {
            return;
        }

        myAni.ChangeAni(aniNumber);
        currentState = newState;
    }

    void UpdateState()      //캐릭터 상태에 따라 일어날 일들 모음
    {
        switch (currentState)
        {
            case State.Idle:
                IdleState();
                break;

            case State.Move:
                MoveState();
                break;

            case State.Attack:
                AttackState();
                break;

            case State.AttackIdle:
                AttackIdleState();
                break;

            case State.Dead:
                DeadState();
                break;

            default:
                break;
        }
    }

    void IdleState()
    {

    }

    void MoveState()
    {
        TurnToDestination();
        MoveToDestination();
    }

    void AttackState()
    {
        AttackTimer = 0f;

        //transform.LookAt(목표지점) : 목표지점을 향해 오브젝트를 회전
        transform.LookAt(curTargetPos);
        ChangeState(State.AttackIdle, PlayerAni.ANI_ATKIDLE);
    }

    void AttackIdleState()
    {
        if (AttackTimer > AttackDelay)
        {
            ChangeState(State.Attack, PlayerAni.ANI_ATTACK);
        }
        AttackTimer += Time.deltaTime;
    }

    void DeadState()
    {

    }

    //캐릭터가 이동할 목표 지점의 좌표
    public void MoveTo(Vector3 tPos)
    {
        if(currentState == State.Dead)
        {
            return;
        }

        curEnemy = null;
        curTargetPos = tPos;
        ChangeState(State.Move, PlayerAni.ANI_WALK);        //walk 상태로 변경
    }

    void TurnToDestination()
    {
        //회전할 목표방향 설정, 목표방향은 목적지 위치에서 자신의 위치를 빼서 구함
        Quaternion lookRotation = Quaternion.LookRotation(curTargetPos - transform.position);

        //Quaternion.RotateTowards(현재의 rotation 값, 최종목표 rotation 값, 최대 회전각)
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            lookRotation, Time.deltaTime * rotAnglePerSecond);
    }

    void MoveToDestination()
    {
        //moveTowards(시작지점, 목표지점, 최대이동거리)
        transform.position = Vector3.MoveTowards(transform.position, curTargetPos, Time.deltaTime * moveSpeed);

        if (curEnemy == null)
        {
            if (transform.position == curTargetPos)
            {
                ChangeState(State.Idle, PlayerAni.ANI_IDLE);
            }
        }
        else if(Vector3.Distance(transform.position, curTargetPos) < AttackDistance)
        {
            ChangeState(State.Attack, PlayerAni.ANI_ATTACK);
        }
    }
}
