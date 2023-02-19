using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private const int TileSize = 4;

    [SerializeField] private int _minTileCount;
    [SerializeField] private int _maxTileCount;
    [SerializeField] private int _fieldPercent;
    [SerializeField] private MapTile[] _tilePrefabs;
    [SerializeField] private MapTile _startTile;
    [SerializeField] private Map _map;

    private int _maxFieldCount;
    private Dictionary<Vector3, MapTile> _spawnedTiles;

    private int _fieldCount => _spawnedTiles.Values.Where(i => i.IsField()).Count();

    private void Start()
    {
        MapTile newTile = Instantiate(_startTile);

        _spawnedTiles = new Dictionary<Vector3, MapTile>();
        _spawnedTiles[newTile.transform.position] = newTile;

        int tileCount = Random.Range(_minTileCount, _maxTileCount);
        _maxFieldCount = (int)Mathf.Round(tileCount * _fieldPercent / 100);

        for (int i = 0; i < tileCount; i++)
            PlaceOneRoom();

        foreach (MapTile tile in _spawnedTiles.Values)
        {
            tile.transform.parent = _map.transform;
        }

        _map.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (var item in _spawnedTiles.Values)
            {
                DestroyImmediate(item.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
            Start();
    }

    private void PlaceOneRoom()
    {
        HashSet<Vector3> vacantPlaces = new HashSet<Vector3>();

        foreach (var tilePosition in _spawnedTiles.Keys)
        {
            AddVacantPlaces(vacantPlaces, new Vector3(tilePosition.x + TileSize, tilePosition.y, tilePosition.z));
            AddVacantPlaces(vacantPlaces, new Vector3(tilePosition.x + TileSize, tilePosition.y, tilePosition.z));
            AddVacantPlaces(vacantPlaces, new Vector3(tilePosition.x, tilePosition.y, tilePosition.z + TileSize));
            AddVacantPlaces(vacantPlaces, new Vector3(tilePosition.x, tilePosition.y, tilePosition.z - TileSize));
        }

        Vector3 position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
        MapTile newTile = Instantiate(GetTile(position));

        newTile.transform.position = position;
        _spawnedTiles[position] = newTile;
    }

    private MapTile GetTile(Vector3 position)
    {
        if (_maxFieldCount == _fieldCount || AdjacentIsField(position))
        {
            var notFields = _tilePrefabs.Where(i => i.IsField() == false).ToList();
            return notFields[Random.Range(0, notFields.Count)];
        }

        if (_fieldCount == 0 && AdjacentIsField(position) == false)
        {
            var fields = _tilePrefabs.Where(i => i.IsField()).ToList();
            return fields[Random.Range(0, fields.Count)];
        }

        return _tilePrefabs[Random.Range(0, _tilePrefabs.Length)];
    }

    private bool AdjacentIsField(Vector3 position)
    {
        foreach (var field in _spawnedTiles.Values.Where(i => i.IsField() || i.IsStartTile()))
            if (Vector3.Distance(field.transform.position, position) <= Mathf.Sqrt(TileSize * TileSize + TileSize * TileSize))
                return true;

        return false;
    }

    private void AddVacantPlaces(HashSet<Vector3> vacantPlaces, Vector3 position)
    {
        if (_spawnedTiles.ContainsKey(position) == false)
            vacantPlaces.Add(position);
    }
}
