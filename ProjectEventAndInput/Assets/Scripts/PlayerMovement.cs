using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private InputAction.CallbackContext _context;
    [SerializeField] private float speed=5f;
    private PlayerInput playerInput;
    [SerializeField] private Animator _animator;
    private float acceleration = 1f;
    private float velocityY;
    private float velocityX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        playerInput.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        Vector2 direction = playerInput.Player.Movement.ReadValue<Vector2>();;
        //direction=direction.normalized;
        transform.position += Time.deltaTime*new Vector3(direction.x, 0, direction.y);
        if (direction!=Vector2.zero)
        {
            velocityY += Time.deltaTime * acceleration*direction.normalized.y;
            velocityX += Time.deltaTime * acceleration*direction.normalized.x;
            
        }
        else
        {
            velocityY = 0;
            velocityX = 0;
        }

        _animator.SetFloat("Velocity Z",velocityY);
        _animator.SetFloat("Velocity X",velocityX);
        
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(Vector3.up*speed,ForceMode.Impulse);
    }
}
