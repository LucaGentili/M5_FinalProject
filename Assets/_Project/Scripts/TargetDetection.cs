using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _target;
    [SerializeField] private float _viewAngle = 45f;
    [SerializeField] private float _sightDistance = 30f;
    [SerializeField] private LayerMask _whatIsObstacle;

    public Transform Target => _target;
    public float ViewAngle => _viewAngle;
    public float SightDistance => _sightDistance;

    public bool CanSeePlayer()
    {
        if (_target == null) return false;

        Vector3 toTarget = _target.position - _head.position;
        toTarget.y = 0f;
        float distance = toTarget.magnitude;

        if (distance > _sightDistance) return false;

        toTarget.Normalize();

        if (Vector3.Dot(_head.forward, toTarget) < Mathf.Cos(_viewAngle * Mathf.Deg2Rad)) return false;

        if (Physics.Linecast(_head.position, _target.position, _whatIsObstacle)) return false;

        return true;
        //Vector3 toTarget = _target.position - transform.position;
        //float sqrDistance = toTarget.magnitude;

        //if (sqrDistance > _sightDistance * _sightDistance) return false;

        //float distance = Mathf.Sqrt(sqrDistance);
        //toTarget /= distance;

        //if (Vector3.Dot(transform.forward, toTarget) < Mathf.Cos(_viewAngle * Mathf.Deg2Rad)) return false;

        //if (Physics.Linecast(_head.position, _target.position + Vector3.up * 0.01f, _whatIsObstacle)) return false;

        //return true;
    }

}
