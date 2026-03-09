using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private GameObject _prefab;

    private float _lastSpawn;
    private bool _canSpawn;

    protected bool CanSpawnNow() => Time.time - _lastSpawn >= _spawnInterval && _canSpawn;

    private void SpawnObject()
    {
        if (!CanSpawnNow()) return;

        GameObject prefab = Instantiate(_prefab, transform.position, transform.rotation, transform);
        _lastSpawn = Time.time;
    }

    private void Update()
    {
        SpawnObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _canSpawn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _canSpawn = false;
    }
}
