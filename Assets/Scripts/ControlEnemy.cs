using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    [SerializeField] EnemyPathConfig _pathConfig;
    List<Transform> _pathPoints;
    private int _pathIndex = 0;

    private void Start()
    {
        _pathPoints = _pathConfig.GetPathPrefab();
        StartCoroutine(Moving());
    }

    public void SetWaveConfig(EnemyPathConfig pathConfig)
    {
        this._pathConfig = pathConfig;
    }

    private IEnumerator Moving()
    {
        while (true) // Continuously loop the movement
        {
            _pathIndex = 0;
            for (_pathIndex = 0; _pathIndex < _pathPoints.Count; _pathIndex++)
            {
                Debug.Log("Waiting for 2 seconds...");
                yield return new WaitForSeconds(2f);

                if (_pathIndex < _pathPoints.Count)
                {
                    var targetPos = _pathPoints[_pathIndex].position;
                    var movementSpeed = 0.1f;

                    while (transform.position != targetPos)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
                        yield return null;
                    }
                }
            }
        }
    }
}