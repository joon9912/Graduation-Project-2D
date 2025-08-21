using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(Player player, StateMachine stateMachine, PlayerData data)
        : base(player, stateMachine, data, "Walk") { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        var input = player.InputHandler;

        if (input == null || (input.XInput == 0 && input.YInput == 0))
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        var input = player.InputHandler;
        if (input == null) return;

        player.Movement?.Move(input.XInput, input.YInput, input.SprintInput, Time.fixedDeltaTime);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
