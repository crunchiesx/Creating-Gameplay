using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    private Rigidbody2D asteroidRb;

    private void Awake()
    {
        asteroidRb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        transform.position = Random.insideUnitCircle.normalized * 50f;
        asteroidRb.AddForce(Random.insideUnitCircle.normalized * Random.Range(0.5f, 1.5f), ForceMode2D.Impulse);
        asteroidRb.AddTorque(Random.Range(-10f, 10f));
    }
}
