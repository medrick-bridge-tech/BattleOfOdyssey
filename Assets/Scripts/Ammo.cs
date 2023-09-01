using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private int ammoCounts;
    public AmmoType GetAmmoType()
    {
        return ammoType;
    }

    public int GetAmmoCounts()
    {
        return ammoCounts;
    }
}