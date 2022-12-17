using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameChecker : MonoBehaviour
{
    [SerializeField] private Map _map;

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
        Destroy(_map.gameObject);
    }
}
