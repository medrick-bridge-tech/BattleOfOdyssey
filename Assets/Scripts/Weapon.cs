using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponProperty weaponProperty;
    private SpriteRenderer _spriteRenderer;

    public AmmoProperty WeaponBullet => weaponProperty.Bullet;
    public Sprite WeaponSkin => weaponProperty.Skin;
    public AudioClip FireSound => weaponProperty.FireSound;
    public int MagazineCapacity => weaponProperty.MagazineCapacity;
    public float FireRange => weaponProperty.FireRange;
    public float FireRate => weaponProperty.FireRate;
    

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = weaponProperty.Skin;
    }
}