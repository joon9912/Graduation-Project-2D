using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
<<<<<<< Updated upstream
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
=======
    #region Variables
    [SerializeField] private float deadZone = 0.2f;

    public Vector2 MoveRaw { get; private set; }
    public int XInput { get; private set; }   // -1 / 0 / 1
    public int YInput { get; private set; }   // -1 / 0 / 1
    public bool SprintInput { get; private set; }
    public bool InteractionInput { get; private set; } // 1회성 → UseInteractionInput()
    public bool EscapeInput { get; private set; }      // 1회성 → UseEscapeInput()
    #endregion

    #region Input Methods
    public void OnMove(InputAction.CallbackContext ctx)
    {
        var v = ctx.ReadValue<Vector2>(); // canceled 시 (0,0)
        MoveRaw = v;
        XInput = Quantize(v.x);
        YInput = Quantize(v.y);
    }

    public void OnSprint(InputAction.CallbackContext ctx)
    {
        if (ctx.started) SprintInput = true;
        if (ctx.canceled) SprintInput = false;
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.started) InteractionInput = true; // 래치
    }

    public void OnEscape(InputAction.CallbackContext ctx)
    {
        if (ctx.started) EscapeInput = true; // 래치
    }

    public void UseInteractionInput() => InteractionInput = false;
    public void UseEscapeInput() => EscapeInput = false;
    #endregion

    #region Helper Methods
    private int Quantize(float a)
    {
        if (Mathf.Abs(a) < deadZone) return 0;
        return a > 0f ? 1 : -1;
>>>>>>> Stashed changes
    }
    #endregion
}
