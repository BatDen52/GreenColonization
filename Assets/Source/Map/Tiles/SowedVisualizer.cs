using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Soil))]
public class SowedVisualizer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private Soil _soil;

    private void Awake()
    {
        _soil = GetComponent<Soil>();
    }

    private void OnEnable()
    {
        _soil.SeedGetted += OnSeedGetted;
        _soil.Sown += OnSown;
    }

    private void OnDisable()
    {
        _soil.SeedGetted -= OnSeedGetted;
        _soil.Sown -= OnSown;
    }

    private void OnSown()
    {
        _text.gameObject.SetActive(false);
        enabled = false;
    }

    private void OnSeedGetted(float currentCount, float needCount)
    {
        _text.text = $"{currentCount}/{needCount}";
    }
}
