using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatVariable moveSpeed;
    private GameInput gameInput;

    private void Start()
    {
        gameInput = GameInput.Instance;
    }

    private void Update()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        var moveDir = gameInput.GetMovementVector2Normalized();
        var moveDistance = moveSpeed.Value * Time.deltaTime;
        transform.position += moveDir.ToVector3() * moveDistance;
    }
}
