using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;
    
    [SerializeField]
    Transform target;
    
    NavMeshAgent agent;

    private Rigidbody2D _rb;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;
    public Vector3? LastTargetPosition;
    public Boolean isChasing = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        
        UpdateTargetDirection();
        RotateTowardsTarget();
        //MoveTowardsTarget();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.awareOfPlayer)
        {
            LastTargetPosition = target.position;
            agent.destination = (Vector3)LastTargetPosition;
            _targetDirection = _playerAwarenessController.DirectionToPlayer.normalized;
            agent.speed = _speed * 1.2f;
        }
        else if (LastTargetPosition.HasValue && Vector2.Distance(transform.position, (Vector2)LastTargetPosition) <= 0.5f)
        {
            agent.speed = _speed;
            LastTargetPosition = null;
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
        agent.SetDestination(point);
        Vector2 enemyToPlayerVector = (agent.path.corners[1] - transform.position).normalized;
        agent.path.ClearCorners();

        // Calcula o ângulo desejado
        float targetAngle = Mathf.Atan2(enemyToPlayerVector.y, enemyToPlayerVector.x) * Mathf.Rad2Deg - 90f;

        // Calcula a rotação necessária para alcançar o ângulo desejado
        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, _rotationSpeed * 10 * Time.deltaTime);

        // Aplica a rotação
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }

}
