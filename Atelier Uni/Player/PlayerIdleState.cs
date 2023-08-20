using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
        : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        player.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0 || zInput != 0)
        {
            player.stateMachine.ChangeState(player.walkState);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && (xInput != 0 || zInput != 0))
        {
            player.stateMachine.ChangeState(player.runState);
        }
    }
}
