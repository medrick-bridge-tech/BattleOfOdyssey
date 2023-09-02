using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponProperty weaponProperty;
    private SpriteRenderer _spriteRenderer;

    public WeaponProperty WeaponProperty => weaponProperty;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = weaponProperty.Skin;
    }
}