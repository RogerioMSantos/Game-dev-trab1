using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool awareOfPlayer {get; private set;}

    public Vector2 DirectionToPlayer {get; private set;}

    [SerializeField]
    private float _playerAwarenessDistance;

    [SerializeField]
    private FieldOfView fieldOfView;

    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<playerMovement>().transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (fieldOfView.IsPlayerDetected())
        {
            awareOfPlayer = true;
        }
        else
        {
            awareOfPlayer = false;
        }
    }
}
