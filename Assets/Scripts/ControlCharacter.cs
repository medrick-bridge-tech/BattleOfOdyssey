using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class ControlCharacter : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float _deltaMoveSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private Vector2 _storeMovement;
    private Animator _animator;
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _deltaMoveSpeed = 0f;
    }
    
    private void Update()
    {
        HandleInput();
        HandleMoveAnimation();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(GetMovingFormula());
    }

    private void Run()
    {
        HandleRunAnimation(0.5f, true);
        _player.DecreaseEnergy();
    }

    private void StopRunning()
    {
        HandleRunAnimation(0f, false);
        if (IsReadyToGainEnergy())
        {
            _player.IncreaseEnergy();
        }
        else
        {
            HandleRunAnimation(0f, false);
        }
    }

    private void Roll()
    {
        _animator.SetTrigger("Roll");
    }

    public Vector2 GetMovement()
    {
        return _storeMovement;
    }
    private void HandleInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _storeMovement = _movement;
        }
        //Roll
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Roll();
        }

        //Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_player.Energy >= 0.5f)
            {
                Run();
            }
        }
        else
        {
            StopRunning();
        }
    }

    private void HandleMoveAnimation()
    {
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed",Convert.ToInt32(_movement.magnitude));
    }

    private void HandleRunAnimation(float runSpeed,bool isRun)
    {
        _animator.SetBool("IsRunning", isRun);
        _deltaMoveSpeed = runSpeed;
    }

    public Vector2 GetDirection()
    {
        return _movement;
    }
    private Vector2 GetMovingFormula()
    {
        var direction = _rigidbody2D.position +
                            _movement.normalized * ((moveSpeed + _deltaMoveSpeed) * Time.fixedDeltaTime);
        return direction;
    }
    
    private bool IsReadyToGainEnergy()
    {
        if (_player.Energy <= 100f && _movement.sqrMagnitude == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}