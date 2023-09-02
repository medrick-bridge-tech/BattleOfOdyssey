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

    [SerializeField] private Dictionary<AmmoProperty, int> ammoInventory = new Dictionary<AmmoProperty, int>();

    private void Start()
    {
        
    }
    public void AddWeapon(Weapon weapon)
    {
        weaponInventory.Add(weapon);
    }
    
    public void AddAmmo(Ammo ammo)
    {
        if (ammoInventory.ContainsKey(ammo.AmmoProperty))
        {
            ammoInventory[ammo.AmmoProperty] += ammo.AmmoProperty.AmmoCounts;
            Debug.Log($"{ammo.AmmoProperty.AmmoType} : {ammoInventory[ammo.AmmoProperty]}");    
        }
        else
        {
            ammoInventory.Add(ammo.AmmoProperty,ammo.AmmoProperty.AmmoCounts);
        }
        


    }
}
