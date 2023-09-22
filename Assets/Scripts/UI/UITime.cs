using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        SetTime();
    }

    private void SetTime()
    {
        var currentDateTime = System.DateTime.Now;
        var formattedDateTime = currentDateTime.ToString("HH:mm:ss");
        timeText.text = formattedDateTime;
    }
}
