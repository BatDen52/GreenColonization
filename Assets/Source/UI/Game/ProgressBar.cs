using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Map _map;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0;
    }

    private void OnEnable()
    {
        _map.SownCountChenged += OnValueChenged;
    }

    private void OnDisable()
    {
        _map.SownCountChenged -= OnValueChenged;
    }

    private void OnValueChenged(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
    }
}
