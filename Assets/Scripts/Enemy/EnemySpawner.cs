using System;
using Unity.Mathematics;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyConfig enemyConfig;

        private void Awake()
        {
            
        }

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
                CreateEnemy(enemy.enemy,enemy.path,enemy.defaultDirection);
            }
        }

        private void CreateEnemy(GameObject enemy, EnemyPathConfig enemyPath, Vector2 initialDirection)
        {
            var spawnPosition = enemyPath.GetPathPrefab()[0].transform.position;
            GameObject newEnemy = Instantiate(enemy, spawnPosition, quaternion.identity);
            if (!enemyPath.isStatic)
            {
                var patrolAgent = newEnemy.GetComponent<PatrolAgent>();
                patrolAgent.Setup(enemyPath);
                StartCoroutine(patrolAgent.StartMoving());
            }
            var detectorAgent = newEnemy.GetComponent<DetectorAgent>();
            detectorAgent.target = initialDirection;
            StartCoroutine(detectorAgent.Detect());
        }
    }
}