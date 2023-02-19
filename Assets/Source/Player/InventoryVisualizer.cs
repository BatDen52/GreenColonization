using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class InventoryVisualizer : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _seedOffset;
    [SerializeField] private int _width = 3;
    [SerializeField] private int _length = 2;
    [SerializeField] private TMP_Text _seedCount;
    private Inventory _inventory;
    private Vector3[] _itemsPosition;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        CulculateIpemsPosition();
    }

    private void OnEnable()
    {
        _inventory.ContentChenged += OnContentChenged;
    }

    private void OnDisable()
    {
        _inventory.ContentChenged -= OnContentChenged;
    }

    private void CulculateIpemsPosition()
    {
        _itemsPosition = new Vector3[_inventory.Capacity];

        float currentX = _startPosition.x;
        float currentY = _startPosition.y;
        float currentZ = _startPosition.z;

        for (int i = 0; i < _itemsPosition.Length; i++)
        {
            currentX = i % _width == 0 ? _startPosition.x : currentX - _seedOffset;
            currentY = _startPosition.y + _seedOffset * (i / (_width * _length));
            currentZ = _startPosition.z - _seedOffset * (i / _width % _length);

            _itemsPosition[i] = new Vector3(currentX, currentY, currentZ);
        }
    }

    private void OnContentChenged(Seed seed, int number)
    {
        seed?.Move(_itemsPosition[number]);
        _seedCount.text = $"{_inventory.Count}/{_inventory.Capacity}";
    }
}
