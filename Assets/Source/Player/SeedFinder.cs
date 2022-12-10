using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class SeedFinder : MonoBehaviour
{
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Seed seed))
        {
            if(_inventory.IsFull == false)
            {
                _inventory.Add(seed);
                Destroy(seed.gameObject);
            }
        }
    }
}
