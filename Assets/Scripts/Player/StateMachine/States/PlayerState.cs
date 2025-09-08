using UnityEngine;

public abstract class PlayerState
{
    #region Variabels
    protected Player player;
    protected StateMachine stateMachine;
    protected PlayerData playerData;
    protected string animBoolName;

    protected bool isAnimationFinished;

    private Vector2 _moveInput;
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
        player.Anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        // Input에 따른 FacingDirection 갱신
        _moveInput = player.InputManager.RawMovementInput;
        player.MovementController.UpdateFacingDirection(_moveInput);

        // MovementController로부터 현재 바라보는 방향 벡터를 가져옵니다.
        Vector2 facingDirection = player.MovementController.FacingDirection;

        // X축(좌우)과 Y축(상하) 중 어느 방향의 값이 더 큰지(절대값 기준) 확인하여 주된 방향을 결정합니다.
        if (Mathf.Abs(facingDirection.x) > Mathf.Abs(facingDirection.y))
        {
            // 좌우 방향이 더 지배적일 경우
            player.Anim.SetBool("facingRight", facingDirection.x > 0);
            player.Anim.SetBool("facingLeft", facingDirection.x < 0);
            player.Anim.SetBool("facingUp", false);
            player.Anim.SetBool("facingDown", false);
        }
        else
        {
            // 상하 방향이 더 지배적일 경우
            player.Anim.SetBool("facingUp", facingDirection.y > 0);
            player.Anim.SetBool("facingDown", facingDirection.y < 0);
            player.Anim.SetBool("facingRight", false);
            player.Anim.SetBool("facingLeft", false);
        }
    }

    public virtual void PhysicsUpdate()
    {

    }
    #endregion
}