using System;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject virualCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            virualCam.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            virualCam.SetActive(false);
        }
    }
    
}