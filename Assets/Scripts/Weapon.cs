using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponProperty weaponProperty;

    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = weaponProperty.skin;
    }

    public WeaponProperty GetWeaponInfo()
    {
        return weaponProperty;
    }
}