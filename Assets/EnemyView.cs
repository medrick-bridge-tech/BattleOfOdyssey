using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private Enemy _enemy;
    private float _viewRange;
    private void Start()
    {
        _enemy = GetComponentInParent<Enemy>();
        _viewRange = _enemy.EnemyViewRange;
        GetComponent<CircleCollider2D>().radius = (_viewRange / 10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _enemy.SetDetection(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _enemy.SetDetection(false);
        }
    }
}
