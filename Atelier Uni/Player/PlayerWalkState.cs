using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
        : base(_player, _stateMachine, _animBoolName)
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

        player.SetVelocity(xInput * player.walkSpeed, zInput * player.walkSpeed);

        if (xInput == 0 && zInput == 0)
        {
            player.stateMachine.ChangeState(player.idleState);
        }

        if (Player.runOnOff == true)
        {
            player.stateMachine.ChangeState(player.runState);
        }
    }

}
