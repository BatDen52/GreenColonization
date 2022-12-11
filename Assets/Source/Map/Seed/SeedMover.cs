using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedMover : MonoBehaviour
{
    private const float StopDistance = 0.000001f;

    [SerializeField] private float _speed;
    private Vector3 _targetPosition;
    private bool _isMoving;
    private Transform _transform;

    public bool IsMoving => _isMoving;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (_isMoving)
        {
            _transform.localPosition = Vector3.MoveTowards(_transform.localPosition, _targetPosition, _speed * Time.deltaTime);

            if (Vector3.Distance(_transform.localPosition, _targetPosition) < StopDistance)
                _isMoving = false;
        }   
    }

    public void StartMove(Vector3 targetPosition)
    {
        _isMoving = true;
        _targetPosition = targetPosition;
    }
}
