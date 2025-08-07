using UnityEngine;

public abstract class PlayerState
{
    #region Variables
    protected Player player;
    protected StateMachine stateMachine;
    protected PlayerData playerData;

    protected bool isAnimationFinished;
    protected string animBoolName;

    protected int xInput;
    protected int yInput;
    protected bool menuOpenCloseInput;
    protected bool interactionInput;
    #endregion

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
        // player.Anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        // player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        // 1) 인풋 초기화
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        interactionInput = player.InputHandler.InteractionInput;
        menuOpenCloseInput = player.InputHandler.MenuOpenCloseInput;

        // 2) 메뉴 
        if (menuOpenCloseInput)
        {
            
        }
    }

    public virtual void PhysicsUpdate()
    {
    }
    #endregion
}