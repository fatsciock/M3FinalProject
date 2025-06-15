using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private AbstractGun weaponPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AbstractGun[] existingWeapons = collision.GetComponentsInChildren<AbstractGun>();

            foreach (var weapon in existingWeapons)
            {
                if (weapon.GetType() == weaponPrefab.GetType())
                {
                    weapon.LevelUp();
                    Destroy(gameObject);
                    return;
                }
            }

            AbstractGun newWeapon = Instantiate(weaponPrefab, collision.transform);

            Destroy(gameObject); // Rimuove il pickup dal mondo
        }
    }
}
