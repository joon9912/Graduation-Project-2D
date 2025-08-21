public class PlayerState
{
    // Blind Classes
    protected Player player;
    protected StateMachine stateMachine;
    protected PlayerData playerData;

    // Blind Variables
    protected bool isAnimationFinished;
    private string animBoolName;

    #region Unity Callback Functions
    public PlayerState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        player.Anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }
    #endregion
}