using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, StateMachine stateMachine, PlayerData data)
        : base(player, stateMachine, data, "Idle") { }

    public override void Enter()
    {
        base.Enter();
        player.Movement?.Stop(); // 정지
    }

    public override void LogicUpdate()
    {
        var input = player.InputHandler;

        if (input != null && (input.XInput != 0 || input.YInput != 0))
        {
            stateMachine.ChangeState(player.WalkState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
