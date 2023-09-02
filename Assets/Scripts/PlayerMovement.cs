using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float energy;
    
    private float _deltaMoveSpeed;
    
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private Animator _animator;
    private Inventory _inventory;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _inventory = FindObjectOfType<Inventory>();
        
        energy = 100f;
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
        DecreaseEnergy();

    }

    private void StopRunning()
    {
        HandleRunAnimation(0f, false);
        if (IsReadyToGainEnergy())
        {
            IncreaseEnergy();
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
    
    private void HandleInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        //Roll
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Roll();
        }

        //Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (energy >= 0.5f)
            {
                Run();
            }
            else
            { 
                StopRunning();
            }
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

    private Vector2 GetMovingFormula()
    {
        var direction = _rigidbody2D.position +
                            _movement.normalized * ((moveSpeed + _deltaMoveSpeed) * Time.fixedDeltaTime);
        return direction;

    }
    
    private bool IsReadyToGainEnergy()
    {
        if (energy <= 100f && _movement.sqrMagnitude == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DecreaseEnergy()
    {
        energy -= 6f*Time.deltaTime;
    }

    private void IncreaseEnergy()
    {
        energy += 1f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gun"))
        {
            Weapon gun = other.GetComponent<Weapon>();
            _inventory.AddWeapon(gun);
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Ammo"))
        {
            Ammo ammo = other.GetComponent<Ammo>();
            _inventory.AddAmmo(ammo);
            other.gameObject.SetActive(false);
        }
    }
}