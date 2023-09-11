using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using RayCastClass;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyDelay;
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyViewRange;
    [SerializeField] private float enemySpeed;
    [SerializeField] private GameObject bullet;
    private bool _isDetectPlayer;
    private float _delay;
    private Animator _animator;
    private MathLogics _mathLogics;
    private Player _player;
    
    public float EnemyDelay => enemyDelay;
    public float EnemyHealth => enemyHealth;
    public float EnemyViewRange => enemyViewRange;
    public float EnemySpeed => enemySpeed;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mathLogics = FindObjectOfType<MathLogics>();
        _player = FindObjectOfType<Player>();
        _isDetectPlayer = false;
        _delay = 0;
    }

    private void FixedUpdate()
    {
        /*
        if (RayCast.DetectPlayer(transform,_player.transform,30,10))
        {
            _animator.SetBool("IsWalking",false);
            _animator.SetBool("IsShooting",true);
            _delay += Time.deltaTime;
            if (_delay >= enemyDelay)
            {
                RoutineShoot();
                _delay = 0;
            }
        }
        else
        {
            _animator.SetBool("IsShooting",false);
        }
        */
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
                HandleShootAnimation(player.transform.position);
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

    private void HandleShootAnimation(Vector3 targetPos)
    {
        Vector2 unitDirection = _mathLogics.UnitVectorMaker(targetPos);
        var horizontal = unitDirection.x;
        var vertical = unitDirection.y;
        
        _animator.SetFloat("Horizontal",horizontal);
        _animator.SetFloat("Vertical",vertical);
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