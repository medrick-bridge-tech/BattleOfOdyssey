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
        CheckRunning();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(GetMovingFormula());
    }

    private void CheckRunning()
    {
        if (energy > 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                HandleRunAnimation(0.5f, true);
                DecreaseEnergy();
            } 
            else 
            {
                HandleRunAnimation(0f, false);
                if (IsReadyToGainEnergy())
                {
                    IncreaseEnergy();
                }
            }
        }
    }
    
    private void HandleInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
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
        energy -= 5f*Time.deltaTime;
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
            _inventory.AddWeapon(gun.GetWeaponInfo());
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Ammo"))
        {
            Ammo ammo = other.GetComponent<Ammo>();
            _inventory.AddAmmo(ammo);
            Destroy(other.gameObject);
        }
    }
}