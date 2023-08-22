using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton_IdleState : Enemy_Skeleton_GroundedState
{
    public Enemy_Skeleton_IdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,
        Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {

    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
