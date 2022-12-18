using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Seed))]
public class SeedResizer : Resizer
{
    [SerializeField] private float _resizeSpeed;
    [SerializeField] private Vector3 _targetSize;
    private Seed _seed;

    private void Awake()
    {
        Transform.localScale = Vector3.zero;
        _seed = GetComponent<Seed>();
    }

    private void OnEnable()
    {
        _seed.Awaking += OnAwaking;
    }

    private void OnDisable()
    {
        _seed.Awaking -= OnAwaking;
    }

    public void OnAwaking()
    {
        SetSizeSmoothly(_resizeSpeed, _targetSize);
    }
}
