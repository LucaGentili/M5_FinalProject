using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private bool _useAnInput;
    [SerializeField] private KeyCode _key = KeyCode.E;
    [SerializeField] private Canvas _canvas;

    private bool _isInside;
    private bool _hasActivated;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;

        _isInside = true;

        if (!_useAnInput)
        {
            Activate();
        }
        else
        {
            _canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;

        _canvas.gameObject.SetActive(false);
        _isInside = false;
    }

    private void Activate()
    {
        Destroy(_door);
    }

    private void Update()
    {
        if (!_useAnInput) return;
        if (!_isInside) return;
        if (_hasActivated) return;

        if (Input.GetKeyDown(_key))
        {
            Activate();
            _hasActivated = true;
        }
    }
}
