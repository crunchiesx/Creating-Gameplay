using UnityEngine;
using UnityEngine.Events;

public class LaserWeapon : Weapon
{
    [Header("References")]
    [SerializeField] private AudioClip fireClip;
    [SerializeField] private AudioClip hitClip;

    [Header("Laser Settings")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float offset = 0.75f;

    [Header("Events")]
    [SerializeField] private UnityEvent onLaserFire;

    private ContactFilter2D hitFilter = ContactFilter2D.noFilter;
    private RaycastHit2D[] hitColliders = new RaycastHit2D[5];

    public override void Fire(Transform origin)
    {
        int numHit = Physics2D.Raycast(origin.position + (origin.up * offset), origin.up, hitFilter, hitColliders);
        onLaserFire?.Invoke();
        AudioManager.Instance.PlaySFX(fireClip);

        if (numHit > 0)
        {
            for (int i = 0; i < numHit; i++)
            {
                if (hitColliders[i].collider.TryGetComponent(out Damageable damageable))
                {
                    damageable.Damage(damage, player.PlayerNumber);

                    ExplosionManager.GenerateExplosion(hitColliders[i].point, 0.2f);
                    AudioManager.Instance.PlaySFX(hitClip);
                    break;
                }
            }
        }
    }
}