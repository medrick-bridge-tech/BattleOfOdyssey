using System;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private UI.UIMessage uiMessage;
    private bool _isActive;
    
    private void Update()
    {
        if (!_isActive)
        {
            if ((GameManager.EnemiesCount / 2) > GameManager.Kills) return;
            uiMessage.UpdateMessage("You have Killed enough guards. Now leave the area.");
            _isActive = true;
        }
    }
}