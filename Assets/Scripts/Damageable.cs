using UnityEngine;

public class Damageable : MonoBehaviour
{
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
            GameObject explosion = GameManager.Instance.explosionPool.GetObject();
            explosion.transform.position = transform.position;
            explosion.transform.localScale = transform.localScale;
            explosion.SetActive(true);
            gameObject.SetActive(false);
            return true;
        }

        return false;
    }
}
