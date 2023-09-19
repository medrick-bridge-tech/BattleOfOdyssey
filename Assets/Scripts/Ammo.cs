using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoProperty ammoProperty;
    private SpriteRenderer _spriteRenderer;
    
    public AmmoProperty AmmoProperty => ammoProperty;

    // TODO: Shortcut for ammo properties
    public int AmmoCount => ammoProperty.AmmoCounts;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = ammoProperty.Skin;
    }
}