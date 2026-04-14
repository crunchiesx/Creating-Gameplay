using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer fireSprite;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float turnSpeed = 10f;

    [Header("Events")]
    [SerializeField] private UnityEvent<float> OnThrust;

    private Rigidbody2D playerRb;

    private float moveAxis;
    private float turnAxis;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        moveAxis = value.Get<float>() * moveSpeed;
        OnThrust?.Invoke(value.Get<float>());
    }

    private void OnTurn(InputValue value)
    {
        turnAxis = value.Get<float>() * turnSpeed;
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(transform.up * moveAxis);
        playerRb.AddTorque(turnAxis);
    }

    private void OnDisable()
    {
        moveAxis = 0f;
        turnAxis = 0f;
        playerRb.linearVelocity = Vector2.zero;
        playerRb.angularVelocity = 0f;
    }
}
