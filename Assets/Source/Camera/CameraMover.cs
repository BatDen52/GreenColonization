using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private const float MaxDistanceToTarget = 0.001f;

    [SerializeField] private float _speed = 10f;
    private Vector3 _targetPosition;
    private Vector3 _lookPosition;

    public event Action GottenTarget;

    private void Awake()
    {
        _targetPosition = transform.position;
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _targetPosition) > MaxDistanceToTarget)
        {
            Move();
        }
    }

    public void SetTargetPosition(Vector3 targetPosition, Vector3 lookPosition)
    {
        _targetPosition = targetPosition;
        _lookPosition = lookPosition;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        transform.LookAt(_lookPosition);

        if (Vector3.Distance(transform.position, _targetPosition) <= MaxDistanceToTarget)
            GottenTarget?.Invoke();
    }
}
