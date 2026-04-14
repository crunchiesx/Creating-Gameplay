using UnityEngine;

public class ExplosionManager : ObjectPool
{
    private static ExplosionManager Instance;

    protected override void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
        base.Awake();
    }

    public static void GenerateExplosion(Vector3 position, float radius)
    {
        if (Instance == null)
        {
            Debug.LogError("No Explosion Manager exist in the scene.");
            return;
        }

        GameObject explosion = Instance.GetObject();
        explosion.transform.position = position;
        explosion.transform.localScale = Vector3.one * radius;
        explosion.SetActive(true);
    }
}