using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool MenuOpenCloseInput { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _menuOpenCloseAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
    }

    #region Input Invoke Methods

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
    }

    public void OnMenuOpenCloseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MenuOpenCloseInput = true;
        }
        if (context.canceled)
        {
            MenuOpenCloseInput = false;
        }
    }

    #endregion

    #region Reset Input Methods
    public void UseMenuOpenCloseInput()
    {
        MenuOpenCloseInput = false;
    }
    #endregion
}