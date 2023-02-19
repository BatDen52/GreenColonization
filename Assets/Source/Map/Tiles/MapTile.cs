using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    public bool IsField()
    {
        Soil soil = GetComponentInChildren<Soil>();

        return soil?.NeedSeedCount > 1;
    }

    public bool IsStartTile()
    {
        Soil soil = GetComponentInChildren<Soil>();

        return soil?.NeedSeedCount == 0;
    }
}
