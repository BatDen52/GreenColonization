using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [SerializeField] private float _needSeedCount;
    [SerializeField] private MeshRenderer _view;
    //[SerializeField] private Grass _grass;
    //[SerializeField] private Field _field;

    private float _seedCount;
    private SeedType _plantedSeed;

    public SeedType PlantedSeed => _plantedSeed;
    public bool IsSow => _needSeedCount == _seedCount;

    public void Plant(SeedType seed)
    {
        if (_plantedSeed == null)
            _plantedSeed = seed;

        _seedCount += seed.Fertility;

        if (IsSow)
        {
            _view.material = seed.SoilMaterial;
           // if (_grass != null)
           //     _grass.Active(seed);
           //
           // if (_field != null)
           //     _field.Active(seed);
        }
    }
}