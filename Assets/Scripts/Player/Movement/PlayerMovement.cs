using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatVariable moveSpeed;
    [SerializeField] private FloatVariable jumpForce;
    private GameInput gameInput;
    private Vector2 moveDir;
    private Rigidbody2D rb;

    private void Start()
    {
        gameInput = GameInput.Instance;
        gameInput.OnJumpAction += AddJumpForce;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
        FlipPlayer();
    }
    
    private void MovePlayer()
    {
        moveDir = gameInput.GetMovementVector2Normalized();
        var moveDistance = moveSpeed.Value * Time.deltaTime;
        transform.position += moveDir.ToVector3() * moveDistance;
    }

    private void FlipPlayer()
    {
        float flipScalar;
        flipScalar = moveDir.x < 0 ? -1 : 1;
        transform.localScale = new Vector3(flipScalar, 1, 1);
    }

    private void AddJumpForce()
    {
        rb.AddForce(Vector2.up * jumpForce.Value);
    }
}
