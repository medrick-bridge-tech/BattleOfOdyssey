using System;
using UnityEngine;

public class RoomBlocker : MonoBehaviour
{
    [SerializeField] private UI.UIMessage uiMessage;
    [SerializeField] private GameObject blockWall;

    private bool _isActive;
    
    private void Update()
    {
        if (!_isActive)
        {
            if ((GameManager.Instance.EnemiesCount / 2) > GameManager.Instance.Kills) return;
            uiMessage.UpdateMessage("You have Killed enough guards. Now leave the area.");
            blockWall.SetActive(false);
            _isActive = true;
        }
    }
}