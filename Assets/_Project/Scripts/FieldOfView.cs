using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private int _subdivisions = 12;
    [SerializeField] private float _interval = 0.5f;

    private LineRenderer _lineRenderer;
    private TargetDetection _playerDetection;

    private void Awake()
    {
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _playerDetection = GetComponent<TargetDetection>();
    }

    private void Start()
    {
        StartCoroutine(CustomUpdate());
    }

    private IEnumerator CustomUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            EvaluateConeOfViewWithQuaternion(_subdivisions);
        }
    }

    private void EvaluateConeOfViewWithQuaternion(int subdivions)
    {
        _lineRenderer.positionCount = subdivions + 1;

        float startAngle = -_playerDetection.ViewAngle;

        Vector3 lineOrigin = Vector3.zero;
        Vector3 forward = Vector3.forward;

        _lineRenderer.SetPosition(0, lineOrigin);

        float deltaAngle = (2 * _playerDetection.ViewAngle / subdivions);

        for (int i = 0; i < subdivions; i++)
        {
            float currentAngle = startAngle + deltaAngle * i;
            Vector3 direction = Quaternion.Euler(0f, currentAngle, 0f) * forward;
            Vector3 point = lineOrigin + direction * _playerDetection.SightDistance;

            _lineRenderer.SetPosition(i + 1, point);
        }
    }

}
