using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class SoilFinder : MonoBehaviour
{
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent(out Soil soil))
        {
            if (_inventory.IsEmpty)
                return;

            if (soil.IsSow)
                return;

            if (soil.PlantedSeed == null || _inventory.ContinsType(soil.PlantedSeed))
            {
                Seed seed = _inventory.GetSeed(soil.PlantedSeed);
                soil.Plant(seed.Type);
            }
        }
    }
}
