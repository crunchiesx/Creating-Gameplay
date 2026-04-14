using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;

    protected Player player;

    protected virtual void Awake()
    {
        player = transform.root.GetComponentInChildren<Player>();
    }

    public abstract void Fire(Transform origin);
}
