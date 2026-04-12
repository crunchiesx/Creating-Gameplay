using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class Player : MonoBehaviour
{
    public static int totalPlayers;

    public int PlayerNumber { get; private set; }

    private int lives = 3;

    private Damageable damageable;

    private void Awake()
    {
        PlayerNumber = totalPlayers++;

        damageable = GetComponent<Damageable>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            if (damageable.Damage(200))
            {
                lives--;
            }
        }
    }
}
