using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (xInput != 0 || yInput != 0)
        {
            stateMachine.ChangeState(player.WalkState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.Core.Movement.SetVelocityZero();
    }
}