using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SeedMover))]
public class Seed : MonoBehaviour
{
    [SerializeField] private SeedType _type;
    [SerializeField] private float _lifeTime;
    private SeedMover _mover;
    private bool _isCollected;

    public SeedType Type => _type;
    public bool IsCollected => _isCollected;
    public float LifeTime => _lifeTime;

    public event Action Collected;
    public event Action Planting;

    private void Awake()
    {
        _mover = GetComponent<SeedMover>();
    }

    public void Collect()
    {
        _isCollected = true;
        Collected?.Invoke();
    }

    public void Palant()
    {
        Planting?.Invoke();
    }

    public void Move(Vector3 targetPosition)
    {
        _mover.StartMove(targetPosition);
    }
}
