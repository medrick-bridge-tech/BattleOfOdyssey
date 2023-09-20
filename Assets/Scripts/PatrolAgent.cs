using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAgent : MonoBehaviour
{
    [SerializeField] private EnemyPathConfig enemyPathConfig;

    private DetectorAgent _detectorAgent;
    private List<Transform> _pathPoints;
    private int _pathIndex;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _detectorAgent = GetComponent<DetectorAgent>();
    }

    public void Setup(EnemyPathConfig pathConfig)
    {
        enemyPathConfig = pathConfig;
        _pathPoints = pathConfig.GetPathPrefab();
    }

    public IEnumerator StartMoving()
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

                    var targetPos = _pathPoints[_pathIndex];
                    _detectorAgent.target = targetPos;
                    HandleAnimation(targetPos.position);
                    var movementSpeed = 0.1f;
                    while (transform.position != targetPos.position && !_animator.GetBool("IsShooting"))
                    {
                        if (!_animator.GetBool("IsAlive"))
                        {
                            yield break;
                        }
                        _animator.SetBool("IsWalking",true);
                        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, movementSpeed * Time.deltaTime);
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

    public Transform GetTargetPosition()
    {
        return _pathPoints[_pathIndex];
    }
}