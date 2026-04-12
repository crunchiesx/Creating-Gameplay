using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    [HideInInspector] public int pointsValue;

    private float defaultScale;
    private Rigidbody2D asteroidRb;

    private void Awake()
    {
        asteroidRb = GetComponent<Rigidbody2D>();
        defaultScale = transform.localScale.x;
    }

    private void OnEnable()
    {
        transform.localScale *= Random.Range(0.5f, 1.5f);
        pointsValue = Mathf.RoundToInt(100 * transform.localScale.x);

        transform.position = Random.insideUnitCircle.normalized * 50f;
        asteroidRb.AddForce(Random.insideUnitCircle.normalized * Random.Range(0.5f, 1.5f), ForceMode2D.Impulse);
        asteroidRb.AddTorque(Random.Range(-10f, 10f));
    }

    private void OnDisable()
    {
        transform.localScale = Vector3.one * defaultScale;
    }
}
