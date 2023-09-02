using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    Cartridge3Mm
}

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Weapon> weaponInventory;

    [SerializeField] private Dictionary<AmmoType, int> ammoInventory = new Dictionary<AmmoType, int>()
    {
        { AmmoType.Cartridge3Mm, 0 }
    };
    
    private void Start()
    {
        
    }
    public void AddWeapon(Weapon weapon)
    {
        weaponInventory.Add(weapon);
    }

    public void AddAmmo(Ammo ammo)
    {
        ammoInventory[ammo.AmmoProperty.AmmoType] += ammo.AmmoProperty.AmmoCounts;
        Debug.Log($"{ammo.AmmoProperty.AmmoType} : {ammoInventory[ammo.AmmoProperty.AmmoType]}");
    }
}
