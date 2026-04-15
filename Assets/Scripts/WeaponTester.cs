using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponTester : MonoBehaviour
{
    private WeaponController weaponController;

    private void Awake()
    {
        weaponController = GetComponent<WeaponController>();
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            weaponController.SelectWeapon(0);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            weaponController.SelectWeapon(1);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            weaponController.SelectWeapon(2);
        }
    }
}
