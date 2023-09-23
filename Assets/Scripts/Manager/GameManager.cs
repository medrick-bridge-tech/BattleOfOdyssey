using System;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public int Coins { get; private set; }
    public int Kills { get; private set; }
    public int EnemiesCount { get; private set; }
    
    [SerializeField] private UIMessage uiMessage;

    public void RegisterEnemy(Enemy.Enemy enemy)
    {
        enemy.onSpawned += AddEnemy;
    }

    public void UnregisterEnemy(Enemy.Enemy enemy)
    {
        enemy.onSpawned -= AddEnemy;
    }

    private void Awake()
    {
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);    
        }
    }

    private void Start()
    {
        if (uiMessage != null)
            uiMessage.UpdateMessage("Kill all the factory guards to open the door.");
    }
    
    public void AddCoin(int count)
    {
        Coins += count;
    }
    public void AddKill()
    {
        Kills++;
    }

    private void AddEnemy()
    {
        EnemiesCount++;
        Debug.Log($"enemies: {EnemiesCount}");
    }

    public void ResetFields()
    {
        Coins = 0;
        Kills = 0;
        EnemiesCount = 0;
    }
}
