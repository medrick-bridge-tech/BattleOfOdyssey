using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoProperty ammoProperty;
    private SpriteRenderer _spriteRenderer;
    
    public AmmoProperty AmmoProperty => ammoProperty;
    public int AmmoCount => ammoProperty.AmmoCounts;
    public AmmoType AmmoType => ammoProperty.AmmoType;
    public float AmmoDamage => ammoProperty.Damage;
    public float AmmoSpeed => ammoProperty.Speed;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = ammoProperty.Skin;
    }
}