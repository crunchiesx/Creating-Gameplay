using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float offset = 0.75f;

    private ProjectilePool projectiles;

    protected override void Awake()
    {
        base.Awake();

        GameObject projectileContainer = new GameObject(projectile.name + " Pool");
        projectileContainer.transform.parent = transform.root;
        projectileContainer.SetActive(false);

        projectiles = projectileContainer.AddComponent<ProjectilePool>();
        projectiles.SetPool(projectile, 20);
        projectiles.playerNumber = player.PlayerNumber;

        projectileContainer.SetActive(true);
    }

    public override void Fire(Transform origin)
    {
        projectiles.GenerateProjectile(origin.position + (origin.up * offset), origin.rotation);
    }
}
