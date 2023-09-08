using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyDelay;
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyViewRange;
    [SerializeField] private float enemySpeed;
    [SerializeField] private GameObject bullet;
    private bool _isDetectPlayer;
    private float _delay;
    public float EnemyDelay => enemyDelay;
    public float EnemyHealth => enemyHealth;
    public float EnemyViewRange => enemyViewRange;
    public float EnemySpeed => enemySpeed;
    
    private void Start()
    {
        _isDetectPlayer = false;
        _delay = 0;
    }

    private void Update()
    {
        if (_isDetectPlayer)
        {
            
            _delay += Time.deltaTime;
            if (_delay >= enemyDelay)
            {
                RoutineShoot();
                _delay = 0;
            }
        }
    }

    public void GetDamage(float damage)
    {
        enemyHealth -= damage;
    }

    private void RoutineShoot()
    {
        var player = FindObjectOfType<Player>().gameObject;
            if (player != null)
            {
                transform.LookAt(player.transform);
                Shoot(player);
            }
    }

    private void Shoot(GameObject target)
    {
        Vector2 shootDirection = (target.transform.position - transform.position).normalized;

        // Instantiate the bullet
        GameObject newBullet = Instantiate(this.bullet, transform.position, Quaternion.identity);

        // Access the Bullet component and set its direction
        Bullet bullet = newBullet.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetRange(enemyViewRange);
            bullet.Move(shootDirection,10f);
        }
    }

    public void SetDetection(bool situation)
    {
        _isDetectPlayer = situation;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            var bullet = other.gameObject;
            enemyHealth -= bullet.GetComponent<Bullet>().AmmoProperty.Damage;
            Destroy(other.gameObject);
        }
    }
}