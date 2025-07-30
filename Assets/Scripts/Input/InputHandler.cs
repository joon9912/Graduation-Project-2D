using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    #region Input Variables
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public bool SprintInput { get; private set; }
    public bool WalkSlowInput { get; private set; }
    public bool InteractionInput { get; private set; }

    private PlayerInput playerInput;
    #endregion

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    #region Input Methods
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
    }

    public void OnSprintInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SprintInput = true;
        }
        if (context.canceled)
        {
            SprintInput = false;
        }
    }

    public void OnWalkSlowInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            WalkSlowInput = true;
        }
        if (context.canceled)
        {
            WalkSlowInput = false;
        }
    }

    public void OnInteractionInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractionInput = true;
        }
        if (context.canceled)
        {
            InteractionInput = false;
        }
    }
    #endregion

    #region Use Input Methods
    public void UseInteractionInput()
    {
        InteractionInput = false;
    }
    #endregion
}
