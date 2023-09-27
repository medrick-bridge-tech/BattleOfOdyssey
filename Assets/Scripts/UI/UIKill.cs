using TMPro;
using UnityEngine;

namespace UI
{
    public class UIKill : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI killText;

        private void Update()
        {
            SetKill();
        }

        private void SetKill()
        {
            killText.text = $": {GameManager.Instance.Kills}";
        }
    }
}