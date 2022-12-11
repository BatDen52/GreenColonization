using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private int _capacity;
    private List<Seed> _seeds = new List<Seed>();

    public int Capacity => _capacity;
    public bool IsFull => _seeds.Count == _capacity;
    public bool IsEmpty => _seeds.Count == 0;

    public event Action<Seed, int> ContentChenged;

    public void Add(Seed seed)
    {
        _seeds.Add(seed);
        seed.transform.parent = _center;
        ContentChenged?.Invoke(seed, _seeds.Count - 1);
    }

    public bool ContinsType(SeedType seedType) => seedType != null && _seeds.Any(s => s.Type == seedType);

    public Seed GetSeed(SeedType seedType)
    {
        Seed suitableSeed = seedType == null ? _seeds.First() : _seeds.First(s => s.Type == seedType);

        if (suitableSeed != null)
        {
            suitableSeed.transform.parent = null;
            _seeds.Remove(suitableSeed);

            for (int i = 0; i < _seeds.Count; i++)
                ContentChenged?.Invoke(_seeds[i], i);
        }

        return suitableSeed;
    }
}
