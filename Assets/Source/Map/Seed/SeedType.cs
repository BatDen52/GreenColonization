using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GreenColonization/SeedsType")]
public class SeedType : ScriptableObject
{
    [SerializeField] private Material _seedMaterial;
    [SerializeField] private Material _soilMaterial;
    [SerializeField] private float _fertility = 1;

    public Material SeedMaterial => _seedMaterial;
    public Material SoilMaterial => _soilMaterial;
    public float Fertility => _fertility;
}
