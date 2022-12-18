using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Soil))]
public class SoilResizer : Resizer
{
    [SerializeField] private float _resizeSpeed;
    [SerializeField] private Vector3 _size;
    private Soil _soil;

    private void Awake()
    {
        _soil = GetComponent<Soil>();
    }

    private void OnEnable()
    {
        _soil.Sown += OnSown;
    }

    private void OnDisable()
    {
        _soil.Sown -= OnSown;
    }

    public void OnSown()
    {
        SetSizeSmoothly(_resizeSpeed, _size, Transform.localScale);
    }
}
