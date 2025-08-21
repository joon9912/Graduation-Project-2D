using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected StateMachine stateMachine;
    protected PlayerData playerData;

    protected bool isAnimationFinished;
    private string animBoolName;

    public PlayerState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        if (!string.IsNullOrEmpty(animBoolName))
            player.Animator.SetBool(animBoolName, true);

        Debug.Log($"{player.name} entered state: {GetType().Name}");
    }

    public virtual void Exit()
    {
        if (!string.IsNullOrEmpty(animBoolName))
            player.Animator.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate() { }
}
