using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static int Coins { get; private set; }
    public static int Kills { get; private set; }

    [SerializeField] private UIMessage uiMessage;

    private void Start()
    {
        uiMessage.UpdateMessage("Kill all the factory guards to open the door.");
    }

    public static void AddCoin(int count)
    {
        Coins += count;
    }
    public static void AddKill()
    {
        Kills++;
    }
}
