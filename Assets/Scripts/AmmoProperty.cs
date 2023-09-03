using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Ammo")]
public class AmmoProperty : ScriptableObject
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private Sprite skin;
    [SerializeField] private int ammoCounts;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletSpeed;
    public AmmoType AmmoType => ammoType;
    public Sprite Skin => skin;
    public int AmmoCounts => ammoCounts;
    public float Damage => bulletDamage;
    public float Speed => bulletSpeed;

}