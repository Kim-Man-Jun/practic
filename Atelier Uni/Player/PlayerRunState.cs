using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerState
{
    public PlayerRunState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
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

        player.SetVelocity(xInput * player.runSpeed, zInput * player.runSpeed);

        if (xInput == 0 && zInput == 0)
        {
            player.stateMachine.ChangeState(player.idleState);
        }

        if (Player.runOnOff == false)
        {
            if(xInput == 0 && zInput == 0)
            {
                player.stateMachine.ChangeState(player.idleState);
            }
            else
            {
                player.stateMachine.ChangeState(player.walkState);
            }
        }
    }
}
