using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private float _deltaMoveSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _storeMovement;
    private Animator _animator;
    private Player _player;

    private Vector2 forward;

    public Vector2 Forward => forward;

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _deltaMoveSpeed = 0f;
    }
    
    private void LateUpdate()
    {
        if (InputManager2D.Direction.magnitude > .01f)
            forward = InputManager2D.Direction.normalized;
        HandleAnimations();
        
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(GetMovingFormula());
    }

    private void HandleAnimations()
    {
        Move();
        if (InputManager2D.IsRolling)
        {
            Roll();
        }
        else if (InputManager2D.IsRunning)
        {
            Run();
        }
        
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
    
    private void Move()
    {
        HandleRunAnimation(0f, false);
        _animator.SetFloat("Horizontal", InputManager2D.Direction.x);
        _animator.SetFloat("Vertical", InputManager2D.Direction.y);
        _animator.SetFloat("Speed",Convert.ToInt32(InputManager2D.Direction.magnitude));
    }

    private void HandleRunAnimation(float runSpeed,bool isRun)
    {
        _animator.SetBool("IsRunning", isRun);
        _deltaMoveSpeed = runSpeed;
    }
    
    private Vector2 GetMovingFormula()
    {
        var direction = _rigidbody2D.position +
                            InputManager2D.Direction.normalized * ((moveSpeed + _deltaMoveSpeed) * Time.fixedDeltaTime);
        return direction;
    }
    
    private bool IsReadyToGainEnergy()
    {
        if (_player.Energy <= 100f && InputManager2D.Direction.sqrMagnitude == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}