using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedReloader : MonoBehaviour
{
    [SerializeField] private Seed _seedPrefab;
    [SerializeField] private List<SpawnPoints> _spawnPoints;
    [SerializeField] private float _spawnDelay;

    private float _currentTime;

    private void Awake()
    {
        _currentTime = 0;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= _spawnDelay)
        {
            _currentTime = 0;

            foreach (var spawnPont in _spawnPoints)
            {
                if(spawnPont.Seed == null)
                {
                    Seed seed = Instantiate(_seedPrefab, spawnPont.Transform);
                    spawnPont.Mature(seed);
                    break;
                }
            }
        }
    }
}
