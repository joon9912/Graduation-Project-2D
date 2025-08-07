using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        if (xInput == 0 && yInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Vector2 inputDir = new Vector2(xInput, yInput).normalized;

        player.Core.Movement.SetVelocity(inputDir * playerData.walkSpeed);
    }
}