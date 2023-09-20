using System;
using Unity.Mathematics;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyConfig enemyConfig;

    private void Start()
    {
        SpawnEnemies(enemyConfig);
    }

    private void Reset()
    {
        if (enemyConfig == null)
        {
            Destroy(GetComponent<EnemySpawner>());
        }
    }

    private void SpawnEnemies(EnemyConfig config)
    {
        foreach (var enemy in config.EnemyPaths)
        {
            CreateEnemy(enemy.Enemy,enemy.Path);
        }
    }
    
    private void CreateEnemy(GameObject enemy, EnemyPathConfig enemyPath)
    {
        var spawnPosition = enemyPath.GetPathPrefab()[0].transform.position;
        GameObject newEnemy = Instantiate(enemy,spawnPosition, quaternion.identity);
        var patrolAgent = newEnemy.GetComponent<PatrolAgent>();
        var detectorAgent = newEnemy.GetComponent<DetectorAgent>();
        patrolAgent.Setup(enemyPath);
        StartCoroutine(patrolAgent.StartMoving());
        StartCoroutine(detectorAgent.Detect());
    }
}