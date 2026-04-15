using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioClip explosionSFX;

    [Header("Settings")]
    [SerializeField] private float health = 100;

    [Header("Events")]
    [SerializeField] private UnityEvent<int> OnDestroyedByPlayer;

    private void OnEnable()
    {
        health = 100;
    }

    public bool Damage(float damage, int playerNumber)
    {
        if (Damage(damage))
        {
            OnDestroyedByPlayer?.Invoke(playerNumber);
            return true;
        }

        return false;
    }

    public bool Damage(float damage)
    {
        if (!isActiveAndEnabled)
        {
            return false;
        }

        health -= damage;
        if (health <= 0)
        {
            ExplosionManager.GenerateExplosion(transform.position, transform.localScale.x);
            AudioManager.Instance.PlaySFX(explosionSFX);
            gameObject.SetActive(false);
            return true;
        }

        return false;
    }
}
