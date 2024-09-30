using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _speed = 2f;

    [SerializeField] private FieldOfView fieldOfView;

    [SerializeField] private GameObject pointA;

    [SerializeField] private GameObject pointB;

    private enemyMovement enemyMovement;

    private Transform currentPoint;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        currentPoint = pointA.transform;

        enemyMovement = GetComponent<enemyMovement>();

        
    }

    private void Update()
    {
        if(!fieldOfView.IsPlayerDetected() && !enemyMovement.LastTargetPosition.HasValue){
            Patrol();
        }
    }

    private void Patrol()
    {
        enemyMovement.RotateToPoint(currentPoint.position);
        
        //_rb.velocity = transform.up * _speed;

        if(Vector2.Distance(transform.position, currentPoint.position) <= 0.5f){
            ChangeCurrentPoint();

            enemyMovement.RotateToPoint(currentPoint.position);
        }
    
    }

    private void ChangeCurrentPoint()
    {
        if(currentPoint == pointA.transform){
            currentPoint = pointB.transform;
            return;
        }
        
        currentPoint = pointA.transform;
    }
    
}