using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum State
    {
        Idle,       //대기, 걷는 모션
        Chase,      //player 추격 모션(점프 모션으로 대체)
        Attack,     //공격 모션
        Dead,       //죽는 모션
        NoState     //아무 일도 없는 상태
    }

    public State currentState = State.Idle;

    #region 스크립트 변수들
    EnemyParams myParams;
    EnemyAni myAni;
    Transform player;
    PlayerParams playerParams;
    CharacterController controller;
    #endregion

    float chaseDistance = 2.5f;
    float attackDistance = 1.5f;
    float reChaseDistance = 2f;

    float rotAnglePerSecond = 360f;
    float moveSpeed = 1.3f;

    float attackDelay = 2f;
    float attackTimer = 0f;

    public ParticleSystem hitEffect;

    public GameObject selectMark;

    //리스폰 시킬 몬스터를 담을 변수
    GameObject myRespawnObj;

    //리스폰 오브젝트에서 생성된 몇번째 몬스터에 대한 정보
    public int spawnID { get; set; }

    //몬스터가 처음 생성될 때의 위치를 저장
    Vector3 originPos;

    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<EnemyAni>();
        myParams = GetComponent<EnemyParams>();
        controller = GetComponent<CharacterController>();

        myParams.deadEvent.AddListener(CallDeadEvent);

        ChangeState(State.Idle, EnemyAni.IDLE);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerParams = player.gameObject.GetComponent<PlayerParams>();

        hitEffect.Stop();
        //myParams.InitParams();
        HideSelection();
    }

    public void HideSelection()
    {
        selectMark.SetActive(false);
    }

    public void ShowSelection()
    {
        selectMark.SetActive(true);
    }

    public void AddToWorldAgain()
    {
        //리스폰 오브젝트에서 처음 생설될 때의 위치와 같게 만듦
        transform.position = originPos;

        GetComponent<EnemyParams>().InitParams();
        GetComponent<BoxCollider>().enabled = true;
    }

    //몬스터가 어느 리스폰 오브젝트로부터 만들어졌는지에 대한 정보를 전달 받는 함수
    public void SetRespawnObj(GameObject respawnObj, int spawnID, Vector3 originPos)
    {
        myRespawnObj = respawnObj;
        this.spawnID = spawnID;
        this.originPos = originPos;
    }

    //몬스터가 죽는 순간 처리되는 함수
    void CallDeadEvent()
    {
        ChangeState(State.Dead, EnemyAni.DIE);

        //몬스터가 죽은 후 아이템 및 동전을 생성
        ObjectManager.instance.DropCoinToPosition(transform.position, myParams.rewardMoney);

        player.gameObject.SendMessage("CurrentEnemyDead");

        SoundManager.instance.PlayEnemyDieSound();

        StartCoroutine(RemoveMeFromWorld());

        hitEffect.Stop();
    }

    IEnumerator RemoveMeFromWorld()
    {
        yield return new WaitForSeconds(1);

        ChangeState(State.Idle, EnemyAni.IDLE);

        //리스폰 오브젝트에 자기 자신을 제거 요청
        myRespawnObj.GetComponent<RespawnObj>().RemoveMonster(spawnID);
    }

    public void ShowHitEffect()
    {
        hitEffect.Play();
    }

    public void ChangeState(State newState, string aniName)
    {
        if (currentState == newState)
        {
            return;
        }

        currentState = newState;
        myAni.ChangeAni(aniName);
    }

    public void AttackCalculate()
    {
        playerParams.SetEnemyAttack(myParams.GetRandomAttack());

        SoundManager.instance.PlayEnemyAttackSound();
    }

    void UpdateState()
    {
        switch (currentState)
        {
            case State.Idle:
                IdleState();
                break;

            case State.Chase:
                ChaseState();
                break;

            case State.Attack:
                AttackState();
                break;

            case State.Dead:
                DeadState();
                break;

            case State.NoState:
                NoState();
                break;
        }
    }

    void IdleState()
    {
        if (GetDistanceFromPlayer() < chaseDistance)
        {
            ChangeState(State.Chase, EnemyAni.WALK);
        }
    }

    void ChaseState()
    {
        if (GetDistanceFromPlayer() < attackDistance)
        {
            ChangeState(State.Attack, EnemyAni.ATTACK);
        }
        else
        {
            TurnToDestination();
            MoveToDestination();
        }
    }

    void AttackState()
    {
        if(player.GetComponent<PlayerFSM>().currentState == PlayerFSM.State.Dead)
        {
            ChangeState(State.NoState, EnemyAni.IDLE);
        }


        if (GetDistanceFromPlayer() > reChaseDistance)
        {
            attackTimer = 0;
            ChangeState(State.Chase, EnemyAni.WALK);
        }
        else
        {
            if (attackTimer > attackDelay)
            {
                transform.LookAt(player.position);
                myAni.ChangeAni(EnemyAni.ATTACK);

                attackTimer = 0f;
            }

            attackTimer += Time.deltaTime;
        }
    }

    void DeadState()
    {
        GetComponent<BoxCollider>().enabled = false;
        hitEffect.Stop();
    }

    void NoState()
    {

    }

    void TurnToDestination()
    {
        Quaternion lookRotation = Quaternion.LookRotation(player.position - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,
            Time.deltaTime * rotAnglePerSecond);
    }

    void MoveToDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position,
            moveSpeed * Time.deltaTime);
    }

    float GetDistanceFromPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
}
