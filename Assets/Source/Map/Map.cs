using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Soil[] _soils;

    public event Action<int, int> SownCountChenged;
    public event Action FullSow;

    private void Awake()
    {
        _soils = GetComponentsInChildren<Soil>() ?? new Soil[0];
    }

    private void OnEnable()
    {
        foreach (var soil in _soils)
        {
            soil.Sown += OnSown;
        }
    }

    private void OnDisable()
    {
        foreach (var soil in _soils)
        {
            soil.Sown -= OnSown;
        }
    }

    private void OnSown()
    {
        int sownCount = _soils.Count(s => s.IsSow);
        SownCountChenged?.Invoke(sownCount, _soils.Length);

        if (sownCount == _soils.Length)
            FullSow?.Invoke();
    }
}
