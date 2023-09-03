using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 0)]
public class WeaponProperty : ScriptableObject
{
    [SerializeField] private Sprite skin;
    [SerializeField] private AmmoProperty bullet;
    [SerializeField] private int magazineCapacity;
    [SerializeField] private float fireRate;
    public Sprite Skin => skin;
    public AmmoProperty Bullet => bullet;
    public int MagazineCapacity => magazineCapacity;
    public float FireRate => fireRate;
}