using System;
using UnityEngine;

public class InputManager
{
    private PlayerActions PlayerActions;
    public event Action OnResetLevel;
    public Vector2 Movement => PlayerActions.PlayerControls.Movement.ReadValue<Vector2>();

    public InputManager()
    {
        PlayerActions = new PlayerActions();
        PlayerActions.PlayerControls.Enable();
        //PlayerActions.PlayerControls.Jump.performed += (c) => OnJump?.Invoke();
        //PlayerActions.PlayerControls.ResetLevel.performed +=  (c) => OnResetLevel?.Invoke();
    }
}
