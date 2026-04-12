using System.Collections;
using UnityEngine;

public class InvincibleOnEnable : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Damageable damageable;

    [Header("Settings")]
    [SerializeField] private float duration = 3f;
    [SerializeField] private float flashInterval = 0.25f;

    private bool firstEnabled = true;

    private void OnEnable()
    {
        if (firstEnabled)
        {
            firstEnabled = false;
            return;
        }

        StartCoroutine(Invincible());
    }

    private IEnumerator Invincible()
    {
        damageable.enabled = false;
        float timer = 0f;
        float interval = 0f;

        bool visible = false;

        while (timer < duration)
        {
            if (interval >= flashInterval)
            {
                spriteRenderer.enabled = visible;
                visible = !visible;
                interval -= flashInterval;
            }

            interval += Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.enabled = true;
        damageable.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = true;
        damageable.enabled = true;
    }
}
