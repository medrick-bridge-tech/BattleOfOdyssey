using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UICoin : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;

        private void Update()
        {
            SetCoin();
        }

        private void SetCoin()
        {
            coinText.text = $": {GameManager.Instance.Coins}";
        }
    }
}