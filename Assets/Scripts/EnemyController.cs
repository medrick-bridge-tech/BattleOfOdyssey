using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyPathConfig pathConfig;

    private PatrolAgent _patrolAgent;
    private DetectorAgent _detectorAgent;
    private Animator _animator;
    private Enemy _enemy;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsAlive",true);
        _enemy = gameObject.GetComponent<Enemy>();
        _patrolAgent = GetComponent<PatrolAgent>();
        _detectorAgent = GetComponent<DetectorAgent>();
    }

    public void SetWaveConfig(EnemyPathConfig pathConfig)
    {
        this.pathConfig = pathConfig;
    }

    private void FixedUpdate()
    {
        HandleDeath();
    }

    private void HandleDeath()
    {
        if (_enemy.EnemyHealth <= 0f)
        {
            _animator.SetBool("IsAlive",false);
        }
    }
}