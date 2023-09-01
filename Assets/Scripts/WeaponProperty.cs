using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 0)]
public class WeaponProperty : ScriptableObject
{
    public Sprite skin;
    public AmmoType ammoType;
    public int magazine;
    public float shotPerSecond;
    public int damage;
}