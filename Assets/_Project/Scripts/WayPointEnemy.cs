using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class WayPointEnemy : Enemy
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _waitTime;

    private int _currentIndex = 0;
    private bool IsWaiting = false;

    public override void HandlePatrol()
    {
        if (_wayPoints.Length == 0 || IsWaiting ) return;

        if (_agent.remainingDistance <= 0.3)
        {
            StartCoroutine(WaitAndAdvance());
        }
        else
        {
            _agent.isStopped = false;
        }
    }

    private IEnumerator WaitAndAdvance()
    {
        _agent.isStopped = true;
        IsWaiting = true;

        yield return new WaitForSeconds(_waitTime);

        IsWaiting = false;
        _agent.isStopped = false;
        _currentIndex = (_currentIndex + 1) % _wayPoints.Length;
        _agent.SetDestination(_wayPoints[_currentIndex].position);
    }
}
