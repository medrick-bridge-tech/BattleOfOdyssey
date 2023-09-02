using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float energy;
    private Inventory _inventory;

    public float Energy => energy;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }
    
    public void DecreaseEnergy()
    {
        energy -= 6f*Time.deltaTime;
    }

    public void IncreaseEnergy()
    {
        energy += 1f * Time.deltaTime;
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