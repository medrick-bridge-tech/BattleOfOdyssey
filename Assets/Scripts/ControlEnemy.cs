using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    [SerializeField] EnemyPathConfig _pathConfig;
    List<Transform> _pathPoints;
    private int _pathIndex = 0;
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
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
                _animator.SetBool("IsWalking",false);
                yield return new WaitForSeconds(2f);
                
                if (_pathIndex < _pathPoints.Count)
                {
                    var targetPos = _pathPoints[_pathIndex].position;
                    var movementSpeed = 0.1f;
                    HandleAnimation(targetPos);
                    while (transform.position != targetPos)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
                        _animator.SetBool("IsWalking",true);
                        yield return null;
                    }
                }
            }
        }
    }

    private void HandleAnimation(Vector3 targetPos)
    {
        var horizontal = 0f;
        var vertical = 0f;
        Vector3 deltaVector = (targetPos - transform.position);
        if (Math.Abs(targetPos.y - transform.position.y) > 0.01)
        {
            vertical = deltaVector.y / Math.Abs(deltaVector.y);
        }

        if (Math.Abs(targetPos.x - transform.position.x) > 0.01)
        {
            horizontal = deltaVector.x / Math.Abs(deltaVector.x);
        }
        _animator.SetFloat("Horizontal",horizontal);
        _animator.SetFloat("Vertical",vertical);
    }
}