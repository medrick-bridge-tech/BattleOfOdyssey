using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    Cartridge3Mm, Cartridge556Mm, Gauge12, FMJ
}

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Weapon> weaponInventory;
    [SerializeField] private Weapon activeWeapon;
    [SerializeField] private Dictionary<AmmoProperty, int> ammoInventory = new Dictionary<AmmoProperty, int>();

    public List<Weapon> WeaponInventory => weaponInventory;
    public Weapon ActiveWeapon => activeWeapon;
    public Dictionary<AmmoProperty, int> AmmoInventory => ammoInventory;
    
    public void ActivateWeapon(int number)
    {
        activeWeapon = weaponInventory[number];
    }
    
    public void AddWeapon(Weapon weapon)
    {
        weaponInventory.Add(weapon);
    }
    
    public void AddAmmo(Ammo ammo)
    {
        if (ammoInventory.ContainsKey(ammo.AmmoProperty))
        {
            ammoInventory[ammo.AmmoProperty] += ammo.AmmoCount;
            Debug.Log($"{ammo.AmmoType} : {ammoInventory[ammo.AmmoProperty]}");    
        }
        else
        {
            ammoInventory.Add(ammo.AmmoProperty,ammo.AmmoProperty.AmmoCounts);
        }
    }

    public void DecreaseAmmo(AmmoProperty ammoProperty)
    {
        ammoInventory[ammoProperty]--;
    }
}
