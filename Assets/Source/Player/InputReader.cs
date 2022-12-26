using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class InputReader : MonoBehaviour
{
    [SerializeField] private LayerMask _movableLayer;
    [SerializeField] private float _maxDistance;

    private Mover _mover;
    private bool _isMoving;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, _maxDistance, _movableLayer))
            {
                _isMoving = true;
                _mover.Move(hit.point);
            }
        }

        if (_isMoving && Input.GetMouseButton(0) == false)
        {
            Stop();
        }
    }

    public void Stop()
    {
        _isMoving = false;
        _mover.Stop();
    }
}
