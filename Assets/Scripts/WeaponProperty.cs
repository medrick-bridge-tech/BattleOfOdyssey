using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 0)]
public class WeaponProperty : ScriptableObject
{
    [SerializeField] private Sprite skin;
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private int magazineCapacity;
    [SerializeField] private float fireRate;

    public Sprite Skin => skin;
    public AmmoType AmmoType => ammoType;
    public int MagazineCapacity => magazineCapacity;
    public float FireRate => fireRate;
}