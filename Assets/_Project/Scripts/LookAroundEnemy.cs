using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundEnemy : Enemy
{
    [SerializeField] private float _rotationSpeed = 40f;

    public override void HandlePatrol()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
