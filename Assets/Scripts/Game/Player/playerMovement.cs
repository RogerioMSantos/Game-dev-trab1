using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movementInput;

    [SerializeField]
    private float _speed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movementInput * _speed;
    }

    private void OnMove(InputValue inputValue)
    {
       _movementInput = inputValue.Get<Vector2>();
    }
}
