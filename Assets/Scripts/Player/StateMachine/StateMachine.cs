using UnityEngine;

public class StateMachine
{
    public PlayerState CurrentState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState?.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        if (newState == null)
        {
            Debug.LogError("[StateMachine] ChangeState called with NULL newState");
            return;
        }
        if (newState == CurrentState)
        {
            Debug.Log("[StateMachine] Ignored: same state");
            return;
        }

        Debug.Log($"[StateMachine] {CurrentState?.GetType().Name ?? "null"} -> {newState.GetType().Name}");

        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
