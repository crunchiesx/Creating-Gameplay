using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private int currentWeaponIndex = 0;
    [SerializeField] private Weapon[] weaponList;

    private void Awake()
    {
        weaponList = GetComponents<Weapon>();
    }

    private void SelectWeapon(int index)
    {
        index = Mathf.Clamp(index, 0, weaponList.Length - 1);
    }

    private void OnFire()
    {
        weaponList[currentWeaponIndex].Fire(transform);
    }
}
