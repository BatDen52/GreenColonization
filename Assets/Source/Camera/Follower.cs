using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    private Transform _camera;

    private void Start()
    {
        _camera = transform;
        _camera.parent = null;
    }

    private void LateUpdate()
    {
        _camera.position = _target.position + _offset;
        _camera.LookAt(_target.position);
    }
}
