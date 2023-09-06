using System;
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

    public void GetDamage(float damage)
    {
        enemyHealth -= damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            var bullet = other.gameObject;
            enemyHealth -= bullet.GetComponent<Bullet>().AmmoProperty.Damage;
        }
    }
}