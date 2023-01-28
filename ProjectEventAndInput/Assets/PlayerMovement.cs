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
        _rigidbody.AddForce(new Vector3(direction.x,0,direction.y)*speed,ForceMode.Force);
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(Vector3.up*speed,ForceMode.Impulse);
    }
}
