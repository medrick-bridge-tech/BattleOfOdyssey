using System;
using Unity.VisualScripting;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private AmmoProperty ammoProperty;
    [SerializeField] private GameObject bulletVFX;
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
        Destroy(gameObject,3f);
        //Move(_character.GetMovement());
    }

    public void Move(Vector2 direction,float speed)
    {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity = direction*speed;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            var destroyVFX = Instantiate(bulletVFX, transform.position, Quaternion.identity);
            Destroy(destroyVFX, 1f);
            Destroy(gameObject);
        }
    }
}