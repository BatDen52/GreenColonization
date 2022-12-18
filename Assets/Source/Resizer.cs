using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resizer : MonoBehaviour
{
    private const float MaxSizeDifference = 0.0001f;

    [SerializeField] private Transform _transform;
    private float _speed;
    private Vector3 _middleSize;
    private Vector3 _finishSize;

    public Transform Transform => _transform;

    private void Update()
    {
        if (Vector3.Distance(_transform.localScale, _middleSize) > MaxSizeDifference)
            Resize(_middleSize);
        else if (Vector3.Distance(_transform.localScale, _finishSize) > MaxSizeDifference)
            _middleSize = _finishSize;
    }

    public void SetSizeSmoothly(float speed, Vector3 finishSize) => SetSizeSmoothly(speed, finishSize, finishSize);

    public void SetSizeSmoothly(float speed, Vector3 middleSize, Vector3 finishSize)
    {
        _speed = speed;
        _middleSize = middleSize;
        _finishSize = finishSize;
    }

    private void Resize(Vector3 targetSize)
    {
        _transform.localScale = Vector3.MoveTowards(_transform.localScale, targetSize, _speed * Time.deltaTime);
    }
}
