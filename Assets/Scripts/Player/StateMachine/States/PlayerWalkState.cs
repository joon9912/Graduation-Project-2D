using UnityEngine;

public class PlayerWalkState : PlayerState
{
    #region Unity Callback Functions
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

        if (player.InputManager.RawMovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.MovementController.SetVelocity(playerData.walkSpeed, player.InputManager.RawMovementInput);
    }
    #endregion
}