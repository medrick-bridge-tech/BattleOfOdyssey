using System;
using Unity.VisualScripting;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private AmmoProperty ammoProperty;
    [SerializeField] private GameObject bulletVFX;
    private CharacterController _characterController;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private float _speed;
    private Inventory _inventory;
    private float _range;
    private Vector2 _startPosition;
    public AmmoProperty AmmoProperty => ammoProperty;

    public void SetAmmoProperty(AmmoProperty ammo)
    {
        ammoProperty = ammo;
    }
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        if (gameObject.CompareTag("Bullet"))
        {
            _characterController = FindObjectOfType<CharacterController>();
            _inventory = FindObjectOfType<Inventory>();
            _direction = InputManager2D.Direction;
            _range = _inventory.ActiveWeapon.WeaponProperty.FireRange;    
        }
        Destroy(gameObject,3f);
    }

    private void Update()
    {
        if (Vector2.Distance(_startPosition, transform.position) >= _range)
        {
            Destroy(gameObject);
        }
    }

    public void Move(Vector2 direction,float speed)
    {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity = direction*speed;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Ambush"))
        {
            var destroyVFX = Instantiate(bulletVFX, transform.position, Quaternion.identity);
            Destroy(destroyVFX, 1f);
            Destroy(gameObject);
        }

    }

    public void SetRange(float range)
    {
        _range = range;
    }


}