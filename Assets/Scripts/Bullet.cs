using System;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private AmmoProperty ammoProperty;
    private ControlCharacter _character;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private float _speed;
    public void SetAmmoProperty(AmmoProperty ammo)
    {
        ammoProperty = ammo;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public float GetDamage()
    {
        return ammoProperty.Damage;
    }

    public float GetSpeed()
    {
        return ammoProperty.Speed;
    }
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _character = FindObjectOfType<ControlCharacter>();
        _direction = _character.GetDirection();
        Move(_character.GetMovement());
    }

    public void Move(Vector2 direction)
    {
        Vector2 velocity = _rigidbody2D.velocity;
        velocity = direction;
        _rigidbody2D.velocity = velocity;
    }
}