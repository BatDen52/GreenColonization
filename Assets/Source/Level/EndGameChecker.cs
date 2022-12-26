using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameChecker : MonoBehaviour
{
    [SerializeField] private Map _map;

    public event Action GameEnded;

    private void OnEnable()
    {
        _map.FullSow += OnFullSow;
    }

    private void OnDisable()
    {
        _map.FullSow -= OnFullSow;
    }

    private void OnFullSow()
    {
        GameEnded?.Invoke();
    }
}
