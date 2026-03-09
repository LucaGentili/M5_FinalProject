using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBallDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 50;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("fafafafa");
        if (other.gameObject.TryGetComponent<LifeController>(out LifeController playerLife))
        {
            Debug.Log("wow");
            playerLife.TakeDamage(_damage);
        }
    }
}
