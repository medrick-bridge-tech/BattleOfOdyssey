using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class UIMessage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI messageText;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void UpdateMessage(string text)
        {
            gameObject.SetActive(true);
            messageText.text = text;
            Invoke(nameof(DisableUIMessage),2f);
        }
        
        private void DisableUIMessage()
        {
            gameObject.SetActive(false);
        }
    }
}
