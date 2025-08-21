using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(Player player, StateMachine stateMachine, PlayerData data)
        : base(player, stateMachine, data, "Walk") { }

    public override void Enter()
    {
        base.Enter(); // Animator.SetBool("Walk", true)
    }

    public override void Exit()
    {
        base.Exit(); // Animator.SetBool("Walk", false)
    }

    public override void LogicUpdate()
    {
        // 이동 입력이 없으면 Idle로 전환
        var input = player.InputHandler;
        if (input == null || (input.XInput == 0 && input.YInput == 0))
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        // 이동 적용
        var input = player.InputHandler;
        if (input == null) return;

        player.Movement?.Move(input.XInput, input.YInput, input.SprintInput, Time.fixedDeltaTime);
    }
}
