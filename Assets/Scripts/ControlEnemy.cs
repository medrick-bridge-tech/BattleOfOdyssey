using System;
using System.Collections;
using System.Collections.Generic;
using RayCastClass;
using Unity.VisualScripting;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    [SerializeField] private EnemyPathConfig _pathConfig;
    private List<Transform> _pathPoints;
    private Animator _animator;
    private Enemy _enemy;
    private EnemyView _enemyView;
    private int _pathIndex = 0;
    private bool _move;

    private void Start()
    {
        _enemyView = GetComponentInChildren<EnemyView>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsAlive",true);
        _enemy = gameObject.GetComponent<Enemy>();
        _pathPoints = _pathConfig.GetPathPrefab();
        _move = true;
        StartCoroutine(Moving());
        StartCoroutine(Detecting());
    }

    public void SetWaveConfig(EnemyPathConfig pathConfig)
    {
        this._pathConfig = pathConfig;
    }

    private void FixedUpdate()
    {
        HandleDead();
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
                    HandleAnimation(targetPos);
                    var movementSpeed = 0.1f;
                    while (transform.position != targetPos && !_animator.GetBool("IsShooting"))
                    {
                        if (_move == false)
                        {
                            yield break;
                        }
                        _animator.SetBool("IsWalking",true);
                        transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
                        
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

    private void HandleDead()
    {
        if (_enemy.EnemyHealth <= 0f)
        {
            _animator.SetBool("IsAlive",false);
            _move = false;
        }
    }

    private IEnumerator Detecting()
    {
        while (true)
        {
            var targetPos = _pathPoints[_pathIndex].position;
            _enemyView.Viewing(targetPos);
        
            bool playerDetected = RayCast.DetectPlayer(transform.position, targetPos, 2f,180, 1);
            _enemy.SetDetection(playerDetected);

            yield return null;
        }
    }

    public void SetMove(bool situation)
    {
        _move = situation;
    }
}