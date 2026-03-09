using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum State { PATROL, CHASE };

    [SerializeField] private Enemy _enemy;

    private State _currentState = State.PATROL;

   

    private void HandleChase()
    {
        if (!_enemy.Detection.CanSeePlayer())
        {
            _currentState = State.PATROL;
            HandlePatrol();
            return;
        }

        _enemy.HandleChase();
    }

    private void HandlePatrol()
    {
        if (_enemy.Detection.CanSeePlayer())
        {
            _currentState = State.CHASE;
            HandleChase();
            return;
        }

        _enemy.HandlePatrol();

    }

    private void Update()
    {
        Debug.Log($"{_currentState}");
        switch (_currentState)
        { 
            case State.PATROL:
                HandlePatrol();
                break;
            case State.CHASE:
                HandleChase();
                break;
        }

    }
}
