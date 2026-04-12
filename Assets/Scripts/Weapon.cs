using UnityEngine;

[RequireComponent(typeof(Player))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private float offsetDistance = 0.75f;

    private int playerNumber;

    private void Awake()
    {
        playerNumber = GetComponent<Player>().PlayerNumber;
    }

    private void OnFire()
    {
        GameObject projectile = GameManager.Instance.projectilePools[playerNumber].GetObject();
        projectile.transform.position = transform.position + (transform.up * offsetDistance);
        projectile.transform.rotation = transform.rotation;
        projectile.SetActive(true);
    }
}
