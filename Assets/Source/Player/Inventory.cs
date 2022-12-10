using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _capacity;

    private List<Seed> _seeds = new List<Seed>();

    public bool IsFull => _seeds.Count == _capacity;
    public bool IsEmpty => _seeds.Count == 0;

    public void Add(Seed seed)
    {
        _seeds.Add(seed);
    }

    public bool ContinsType(SeedType seedType) => seedType != null && _seeds.Any(s => s.Type == seedType);

    public Seed GetSeed(SeedType seedType)
    {
        Seed seed = seedType == null ? _seeds.First() : _seeds.First(s => s.Type == seedType);

        _seeds.Remove(seed);
        return seed;
    }
}
