using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy_Skeleton : Enemy
{
    public Enemy_Skeleton_IdleState idleState { get; private set; }
    public Enemy_Skeleton_MoveState moveState { get; private set; }
    public Enemy_Skeleton_BattleState battleState { get; private set; }
    public Enemy_Skeleton_AttackState attackState { get; private set; }
    public Enemy_Skeleton_StunnedState stunnedState { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        idleState = new Enemy_Skeleton_IdleState(this, stateMachine, "Idle", this);
        moveState = new Enemy_Skeleton_MoveState(this, stateMachine, "Move", this);
        battleState = new Enemy_Skeleton_BattleState(this, stateMachine, "Move", this);
        attackState = new Enemy_Skeleton_AttackState(this, stateMachine, "Attack", this);
        stunnedState = new Enemy_Skeleton_StunnedState(this, stateMachine, "Stunned", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.U))
        {
            stateMachine.ChangeState(stunnedState);
        }
    }

    public override bool CanBeStunned()
    {
        if (base.CanBeStunned())
        {
            stateMachine.ChangeState(stunnedState);
            return true;
        }
        return false;
    }
}
