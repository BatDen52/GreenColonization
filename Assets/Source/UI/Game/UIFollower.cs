using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIFollower : MonoBehaviour
{
    [SerializeField] private float _updatePositionDistance = 5f;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    private RectTransform _uiItem;
    private Camera _camera;

    private void Start()
    {
        _uiItem = transform as RectTransform;
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 goalPosition = _camera.WorldToScreenPoint(_target.position) + _offset;

        if (Vector3.Distance(_uiItem.position, goalPosition) > _updatePositionDistance)
            _uiItem.position = goalPosition;
    }
}
