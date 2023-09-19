using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorAgent : MonoBehaviour
{
    public Transform target;
    
    private Enemy _enemy;
    private PatrolAgent _patrolAgent;
    
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        target = transform;
    }

    public IEnumerator Detect()
    {
        while (true)
        {
            var targetPos = target.position;
            bool playerDetected = RayCast.DetectPlayer(transform.position, targetPos, 2f,180, 1);
            _enemy.SetDetection(playerDetected);
            yield return null;
        }
    }
}