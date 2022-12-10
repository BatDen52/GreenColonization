using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] private SeedType _type;

    public SeedType Type => _type;
}
