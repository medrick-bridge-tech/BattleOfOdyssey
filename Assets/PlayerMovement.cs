using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float moveSpeed;

    private float _extraMoveSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private Animator _animator;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _extraMoveSpeed = 0f;
    }
    
    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        _animator.SetFloat("Horizontal",_movement.x);
        _animator.SetFloat("Vertical",_movement.y);
        _animator.SetFloat("Speed",_movement.sqrMagnitude);
        CheckRunning();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * ((moveSpeed+_extraMoveSpeed) * Time.fixedDeltaTime));
    }

    private void CheckRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("IsRunning", true); 
            _extraMoveSpeed = 0.5f;
             
        }else 
        {
            _animator.SetBool("IsRunning", false);
            _extraMoveSpeed = 0f; 
        }
    }
    
}
