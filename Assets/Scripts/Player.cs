using System;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float energy;
    [SerializeField] private GameObject bullet;
    private Inventory _inventory;
    private ControlCharacter _character;
    public float Energy => energy;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        _character = FindObjectOfType<ControlCharacter>();
    }

    private void OnGUI()
    {
        //  TODO: How to make this better
        if (Event.current.isKey)
        {
            if (CheckNumpadEnter())
            {
                int keyNumber = Convert.ToInt32(Event.current.keyCode);
                if (keyNumber > 0)
                {
                    _inventory.ActivateWeapon(keyNumber-48);
                    Debug.Log($"{keyNumber-48} : {_inventory.ActiveWeapon}");
                }
            }
        }    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        var newBullet = Instantiate(bullet,transform.position,quaternion.identity);
        newBullet.GetComponent<Bullet>().SetAmmoProperty(_inventory.ActiveWeapon.WeaponProperty.Bullet);
    }
    public void DecreaseEnergy()
    {
        energy -= 6f*Time.deltaTime;
    }

    public void IncreaseEnergy()
    {
        energy += 1f * Time.deltaTime;
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
    }
}