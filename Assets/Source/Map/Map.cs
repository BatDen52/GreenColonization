using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private List<Soil> _soils;

    public event Action<int, int> SownCountChenged;

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
        SownCountChenged?.Invoke(_soils.Count(s => s.IsSow), _soils.Count);
    }
}
