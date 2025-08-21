using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

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

    public void UseMenuOpenCloseInput()
    {
        MenuOpenCloseInput = false;
    }
}