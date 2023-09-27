using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIWeaponBar : MonoBehaviour
    {
        [SerializeField] private Image[] weaponSlotImages;
        [SerializeField] private Vector2 activateWeaponImageSize;
        [SerializeField] private Inventory inventory;

        private RectTransform _parentRectTransform;
        private Vector2 _defaultSize;
        private TextMeshProUGUI _ammoCounts;
        
        private void Awake()
        {
            _parentRectTransform = weaponSlotImages[0].transform.parent.GetComponent<RectTransform>();
            _defaultSize = _parentRectTransform.sizeDelta;
        }
    
        private void Update()
        {
            foreach (var weapon in inventory.WeaponInventory)
            {
                var index = inventory.WeaponInventory.IndexOf(weapon);
                weaponSlotImages[index].sprite = weapon.WeaponSkin;
                if (weapon == inventory.ActiveWeapon)
                {
                    weaponSlotImages[index].transform.parent.GetComponent<RectTransform>().sizeDelta = activateWeaponImageSize;
                    weaponSlotImages[index].GetComponentInChildren<TextMeshProUGUI>().text = GetBulletAmount(weapon);
                }
                else
                {
                    weaponSlotImages[index].transform.parent.GetComponent<RectTransform>().sizeDelta = _defaultSize;
                    weaponSlotImages[index].GetComponentInChildren<TextMeshProUGUI>().text = "";
                }
            }
        }

        private string GetBulletAmount(Weapon weapon)
        {
            if(inventory.AmmoInventory.TryGetValue(inventory.ActiveWeapon.WeaponBullet, out int value))
            {
                return inventory.AmmoInventory[weapon.WeaponBullet].ToString();
            }
            else
            {
                return "0";
            }
        }
    }
}