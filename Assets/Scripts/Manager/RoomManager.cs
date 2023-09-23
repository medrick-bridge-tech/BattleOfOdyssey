using System;
using Cinemachine;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private GameObject _virtualCamera;

    private void Awake()
    {
        _virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>().gameObject;
        _virtualCamera.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _virtualCamera.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _virtualCamera.SetActive(false);
        }
    }
    
}