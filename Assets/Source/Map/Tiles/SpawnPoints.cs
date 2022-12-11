using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    private Seed _seed;
    private Transform _transform;

    public Seed Seed => _seed;
    public Transform Transform => _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Mature(Seed seed)
    {
        _seed = seed;
        seed.Collected += OnCollected;
    }

    public void OnCollected()
    {
        _seed = null;
    }
}
