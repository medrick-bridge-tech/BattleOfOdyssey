using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private Object nextScene;
    [SerializeField] private UI.UIMessage uiMessage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiMessage.UpdateMessage("Press 'Enter' to exit.");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(nextScene.name);
            }
        }
    }
}
