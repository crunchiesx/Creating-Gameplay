using UnityEngine;

public class ProjectilePool : ObjectPool
{
    [HideInInspector]
    public int playerNumber;

    protected override GameObject CreateObject()
    {
        GameObject createdObject = base.CreateObject();
        if (createdObject.TryGetComponent(out Projectile projectile))
        {
            projectile.playerNumber = playerNumber;
        }

        return createdObject;
    }

    public void GenerateProjectile(Vector3 position, Quaternion rotation)
    {
        GameObject projectile = GetObject();
        projectile.transform.position = position;
        projectile.transform.rotation = rotation;
        projectile.SetActive(true);
    }
}
