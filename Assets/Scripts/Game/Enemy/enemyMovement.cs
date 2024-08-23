using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rb;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        MoveTowardsTarget();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.awareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer.normalized;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection != Vector2.zero)
        {
            // Calcula o ângulo desejado
            float targetAngle = Mathf.Atan2(_targetDirection.y, _targetDirection.x) * Mathf.Rad2Deg - 90f;

            // Calcula a rotação necessária para alcançar o ângulo desejado
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, _rotationSpeed * Time.deltaTime);

            // Aplica a rotação
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void MoveTowardsTarget()
    {
        if (_targetDirection != Vector2.zero)
        {
            _rb.velocity = transform.up * _speed;
        }
        else
        {
            //_rb.velocity = Vector2.zero;
        }
    }

    public void RotateToPoint(Vector3 point)
    {
        Vector2 enemyToPlayerVector = (point - transform.position).normalized;

        // Calcula o ângulo desejado
        float targetAngle = Mathf.Atan2(enemyToPlayerVector.y, enemyToPlayerVector.x) * Mathf.Rad2Deg - 90f;

        // Calcula a rotação necessária para alcançar o ângulo desejado
        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, _rotationSpeed * 10 * Time.deltaTime);

        // Aplica a rotação
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
