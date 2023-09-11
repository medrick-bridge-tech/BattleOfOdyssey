using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using RayCastClass;
public class EnemyView : MonoBehaviour
{
    private Enemy _enemy;
    private ControlEnemy _controlEnemy;
    private float _viewRange;
    private Vector2 _target;

    public void Viewing(Vector2 target)
    {
        if (RayCast.DetectPlayer(transform.position,target,30,1))
        {
            Debug.Log("Player deteced");
        }
    }
    private void Start()
    {
        _enemy = GetComponentInParent<Enemy>();
        _controlEnemy = GetComponentInParent<ControlEnemy>();
        _viewRange = _enemy.EnemyViewRange;
    }

    private void FixedUpdate()
    {
        
    }
}
