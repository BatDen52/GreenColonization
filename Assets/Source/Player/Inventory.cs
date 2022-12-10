using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _capacity;

    private List<Seed> _seeds = new List<Seed>();

    public bool IsFull => _seeds.Count == _capacity;

    public void Add(Seed seed)
    {
        _seeds.Add(seed);
    }
}
