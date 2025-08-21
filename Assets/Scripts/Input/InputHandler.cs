using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)] // Player보다 먼저 갱신되도록
public class InputHandler : MonoBehaviour
{
    [SerializeField] private float deadZone = 0.2f;

    public Vector2 MoveRaw { get; private set; }
    public int XInput { get; private set; }
    public int YInput { get; private set; }
    public bool SprintInput { get; private set; }
    public bool InteractionInput { get; private set; }
    public bool EscapeInput { get; private set; }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        var v = ctx.ReadValue<Vector2>();
        MoveRaw = v;

        XInput = Mathf.Abs(v.x) < deadZone ? 0 : (v.x > 0 ? 1 : -1);
        YInput = Mathf.Abs(v.y) < deadZone ? 0 : (v.y > 0 ? 1 : -1);
    }

    public void OnSprint(InputAction.CallbackContext ctx)
    {
        if (ctx.started)  SprintInput = true;
        if (ctx.canceled) SprintInput = false;
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.started) InteractionInput = true;
    }

    public void OnEscape(InputAction.CallbackContext ctx)
    {
        if (ctx.started) EscapeInput = true;
    }

    public void UseInteractionInput() => InteractionInput = false;
    public void UseEscapeInput()      => EscapeInput = false;
}
