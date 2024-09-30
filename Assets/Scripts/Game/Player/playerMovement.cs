using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movementInput;
    private Vector2 _smoothMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    // [SerializeField] 
    // private FieldOfView fieldOfView;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void SetPlayerVelocity()
    {
        _smoothMovementInput = Vector2.SmoothDamp(_smoothMovementInput, _movementInput, ref _movementInputSmoothVelocity, 0.1f);

        _rb.velocity = _smoothMovementInput * _speed;
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(transform.forward, _smoothMovementInput);
            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, newRotation, _rotationSpeed * Time.deltaTime);

            _rb.MoveRotation(finalRotation);
            //fieldOfView.setAimDirection(_rb.rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void Update()
    {
        //fieldOfView.setOrigin(_rb.position);
    }
}
