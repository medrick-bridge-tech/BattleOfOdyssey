using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private Player player;
    
        private void Update()
        {
            healthBar.fillAmount = player.Health / 100;
        }
    }
}
