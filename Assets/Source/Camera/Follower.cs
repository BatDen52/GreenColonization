using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    private Transform _camera;

    public Vector3 GoalPosition => _target.position + _offset;
    public Vector3 Target => _target.position;

    private void Start()
    {
        _camera = transform;
        _camera.parent = null;
    }

    private void LateUpdate()
    {
        _camera.position = GoalPosition;
        _camera.LookAt(_target.position);
    }
}
