using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private TargetDetection _detection;
    protected NavMeshAgent _agent;

    public TargetDetection Detection => _detection;
    public NavMeshAgent Agent => _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public virtual void HandleChase()
    {
        _agent.SetDestination(_detection.Target.position);
    }
    public abstract void HandlePatrol();
}
