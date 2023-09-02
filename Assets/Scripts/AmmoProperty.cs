using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Ammo")]
public class AmmoProperty : ScriptableObject
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private Sprite skin;
    [SerializeField] private int ammoCounts;
    [SerializeField] private int damage;
    
    
    public AmmoType AmmoType => ammoType;
    public int AmmoCounts => ammoCounts;
    public int Damage => damage;
    public Sprite Skin => skin;
}