using UnityEngine;

public class Damageable : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioClip explosionSFX;

    [Header("Settings")]
    [SerializeField] private float health = 100;

    private void OnEnable()
    {
        health = 100;
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
