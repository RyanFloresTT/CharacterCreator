using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;

    public Action OnInteractAction;
    public Action OnAlternateInteractAction;
    public Action OnPauseAction;
    public Action OnJumpAction;

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Handle_Interact;
        playerInputActions.Player.Pause.performed += Handle_Pause;
        playerInputActions.Player.Jump.performed += Handle_Jump;

        Instance = this;
    }

    private void OnDestroy()
    {
        playerInputActions.Player.Interact.performed -= Handle_Interact;
        playerInputActions.Player.Pause.performed -= Handle_Pause;

        playerInputActions.Dispose();
    }

    private void Handle_Pause(InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke();
    }

    private void Handle_Interact(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke();
    }
    private void Handle_Jump(InputAction.CallbackContext obj)
    {
        OnJumpAction?.Invoke();
    }

    public Vector2 GetMovementVector2Normalized()
    {
        return Vector2.zero;
    }
}