using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton_MoveState : Enemy_Skeleton_GroundedState
{
    public Enemy_Skeleton_MoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy)
        : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, enemy.rb.velocity.y);

        if(enemy.isWallDetected() || !enemy.isGroundDetected())
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
