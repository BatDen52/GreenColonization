using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [SerializeField] private float _needSeedCount;
    [SerializeField] private MeshRenderer _view;
    [SerializeField] private Grass _grass;
    [SerializeField] private Field _field;

    private float _seedCount;
    private SeedType _plantedSeed;

    public SeedType PlantedSeed => _plantedSeed;
    public bool IsSow => _needSeedCount == _seedCount;

    public event Action Sown;

    public void Plant(Seed seed)
    {
        if (seed == null || seed.Type == null)
            return;

        SeedType seedType = seed.Type;

        if (_plantedSeed == null)
            _plantedSeed = seedType;

        _seedCount += seedType.Fertility;

        seed.Palant();

        if (IsSow)
        {
            _view.material = seedType.SoilMaterial;
            
            if (_grass != null)
                _grass.Active(seedType);

            if (_field != null)
                _field.Active(seedType);

            Sown?.Invoke();
        }
    }
}