using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorAgent : MonoBehaviour
{
    public Vector2 target;

    private Enemy _enemy;
    private PatrolAgent _patrolAgent;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    
    // public void SetTarget(Vector2 targetDirection)
    // {
    //     target = targetDirection;
    // }
    

    public IEnumerator Detect()
    {
        while (true)
        {
            var targetPos = target;
            bool playerDetected = RayCast.DetectPlayer(transform.position, targetPos, 2f,75, 1);
            _enemy.SetDetection(playerDetected);
            yield return null;
        }
    }
}