using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyDelay;
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyViewRange;
    [SerializeField] private float enemySpeed;

    public float EnemyDelay => enemyDelay;
    public float EnemyHealth => enemyHealth;
    public float EnemyViewRange => enemyViewRange;
    public float EnemySpeed => enemySpeed;
}