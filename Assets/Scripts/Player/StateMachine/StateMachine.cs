// StateMachine.cs
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
        if (newState == null || newState == CurrentState) return;
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }
}
