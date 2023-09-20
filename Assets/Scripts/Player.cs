using System;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float energy;
    [SerializeField] private GameObject bullet;
    private Inventory _inventory;
    private CharacterController _characterController;
    
    public float Energy => energy;
    
    private void Start()
    {
        _inventory = GetComponent<Inventory>();
        _characterController = GetComponent<CharacterController>();
    }

    private void OnGUI()
    {
        if (Event.current.isKey)
        {
            if (CheckNumpadEnter())
            {
                int keyNumber = Convert.ToInt32(Event.current.keyCode)-49;
                if (keyNumber >= 0 && keyNumber < _inventory.WeaponInventory.Count)
                {
                    _inventory.ActivateWeapon(keyNumber);
                    Debug.Log($"{keyNumber} : {_inventory.ActiveWeapon}");
                }
            }
        }    
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.J) && _inventory.ActiveWeapon != null)
        {
            if (BulletAmountCheck())
            {
                Shoot();
            }
        }
    }
    private void Shoot()
    {
        CreateBullet();
        FindObjectOfType<CinemachineShake>().ShakeCamera(0.5f,0.1f);
    }

    private void CreateBullet()
    {
        var position = transform.position;
        var direction = new Vector3(_characterController.Forward.x/10,_characterController.Forward.y/10,0f);
        var newBullet = Instantiate(bullet,position + direction,Quaternion.identity);
        newBullet.GetComponent<Bullet>().SetAmmoProperty(_inventory.ActiveWeapon.WeaponProperty.Bullet);
        newBullet.GetComponent<Bullet>().SetRange(_inventory.ActiveWeapon.WeaponProperty.FireRange);
        newBullet.GetComponent<Bullet>().Move(_characterController.Forward,_inventory.ActiveWeapon.WeaponProperty.Bullet.Speed);
        _inventory.DecreaseAmmo(_inventory.ActiveWeapon.WeaponProperty.Bullet);
    }
    
    private bool CheckNumpadEnter()
    {
        if (Input.GetKey(KeyCode.Alpha0) || Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) ||
            Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Alpha5) ||
            Input.GetKey(KeyCode.Alpha6) || Input.GetKey(KeyCode.Alpha7) || Input.GetKey(KeyCode.Alpha8) || 
            Input.GetKey(KeyCode.Alpha9))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool BulletAmountCheck()
    {
        if (_inventory.AmmoInventory.TryGetValue(_inventory.ActiveWeapon.WeaponProperty.Bullet, out int value))
        {
            if (value > 0)
            {
                return true;
            }
        }
        return false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gun"))
        {
            Weapon gun = other.GetComponent<Weapon>();
            _inventory.AddWeapon(gun);
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Ammo"))
        {
            Ammo ammo = other.GetComponent<Ammo>();
            _inventory.AddAmmo(ammo);
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("EnemyBullet"))
        {
            health -= other.GetComponent<Bullet>().AmmoProperty.Damage;
            Destroy(other.gameObject);
        }
    }
    
    public void DecreaseEnergy()
    {
        energy -= 6f*Time.deltaTime;
    }

    public void IncreaseEnergy()
    {
        energy += 1f * Time.deltaTime;
    }
}