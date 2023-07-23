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

    PlayerAni myAni;

    Vector3 curTargetPos;                           //마우스 클릭 지점, 목적지의 좌표
    public float rotAnglePerSecond = 360f;          //1초에 플레이어의 방향을 수치만큼 회전
    public float moveSpeed = 2f;                    //초당 수치의 속도로 이동

    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<PlayerAni>();
        //myAni.ChangeAni(PlayerAni.ANI_WALK);
        ChangeState(State.Idle, PlayerAni.ANI_IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
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
                break;
            case State.Move:
                TurnToDestination();
                MoveToDestination();
                break;
            case State.Attack:
                break;
            case State.AttackIdle:
                break;
            case State.Dead:
                break;
            default:
                break;
        }
    }

    //캐릭터가 이동할 목표 지점의 좌표
    public void MoveTo(Vector3 tPos)
    {
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

        if (transform.position == curTargetPos)
        {
            ChangeState(State.Idle, PlayerAni.ANI_IDLE);
        }
    }
}
