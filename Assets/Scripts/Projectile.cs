using System;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private int playerNumber;

    [Header("Projectile Settings")]
    [SerializeField] private float damage = 30f;
    [SerializeField] private float speed = 30f;
    [SerializeField] private float duration = 5f;

    [Space]

    [SerializeField] private ContactFilter2D hitFilter;

    [Header("References")]
    [SerializeField] private AudioClip fireClip;
    [SerializeField] private AudioClip hitClip;

    private Collider2D[] hitColliders = new Collider2D[5];

    private float timer;

    private void OnEnable()
    {
        AudioManager.Instance.PlaySFX(fireClip);
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;

        int numHit = Physics2D.OverlapBox(transform.position, transform.localScale, transform.rotation.eulerAngles.z, hitFilter, hitColliders);

        if (numHit > 0)
        {
            for (int i = 0; i < numHit; i++)
            {
                if (hitColliders[i].TryGetComponent(out Damageable damageable))
                {
                    if (damageable.Damage(damage))
                    {

                    }

                    AudioManager.Instance.PlaySFX(hitClip);
                    gameObject.SetActive(false);
                    break;
                }
            }
        }

        timer += Time.deltaTime;
        if (timer >= duration)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        timer = 0f;
    }
}
