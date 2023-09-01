using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    Cartridge3Mm
}

[Serializable]
public class AmmoInventory
{
    public AmmoType ammoType;
    public int count;
}
public class Inventory : MonoBehaviour
{
    [SerializeField] private List<WeaponProperty> weaponInventory;
    [SerializeField] private List<AmmoInventory> ammoInventory;
    public void AddWeapon(WeaponProperty weapon)
    {
        weaponInventory.Add(weapon);
    }

    public void AddAmmo(Ammo ammo)
    {
        ammoInventory.Add(new AmmoInventory
        {
            ammoType = ammo.GetAmmoType(),
            count = ammo.GetAmmoCounts()
        });
    }
}
