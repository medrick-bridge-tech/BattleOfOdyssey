using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Ammo")]
public class AmmoProperty : ScriptableObject
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private Sprite skin;
    [SerializeField] private Sprite bulletSkin;
    [SerializeField] private int ammoCounts;
    [SerializeField] private int bulletDamage;

    public AmmoType AmmoType => ammoType;
    public int AmmoCounts => ammoCounts;
    public int Damage => bulletDamage;
    public Sprite Skin => skin;
    public Sprite BulletSkin => bulletSkin;
}