using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Coins { get; private set; }
    public static int Kills { get; private set; }
    public static int EnemiesCount { get; private set; }
    
    [SerializeField] private UIMessage uiMessage;

    private void OnEnable()
    {
        Enemy.Enemy.OnSpawned += AddEnemy;
    }

    private void OnDisable()
    {
        Enemy.Enemy.OnSpawned -= AddEnemy;
    }

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

    private void AddEnemy()
    {
        EnemiesCount++;
        Debug.Log($"enemies: {EnemiesCount}");
    }
}
