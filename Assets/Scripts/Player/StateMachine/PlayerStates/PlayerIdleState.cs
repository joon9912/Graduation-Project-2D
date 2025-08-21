// PlayerIdleState.cs
public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, StateMachine stateMachine, PlayerData data)
        : base(player, stateMachine, data, "Idle") { }

    public override void Enter()
    {
        base.Enter();            // Animator.SetBool("Idle", true)
        player.Movement?.Stop(); // 완전히 정지
    }

    public override void LogicUpdate()
    {
        // 이동 입력이 생기면 Walk로 전환
        var input = player.InputHandler;
        if (input != null && (input.XInput != 0 || input.YInput != 0))
        {
            stateMachine.ChangeState(player.WalkState);
        }
    }

    public override void Exit()
    {
        base.Exit(); // Animator.SetBool("Idle", false)
    }
}
