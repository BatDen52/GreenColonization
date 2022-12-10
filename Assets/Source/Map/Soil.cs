using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [SerializeField] private float _needSeedCount;
    [SerializeField] private Soil _replaceView;

    private float _seedCount;
    private bool _isSow = false;

    public void Sow()
    {
        //заменить на состояния поля (состояние - скрипт со своим визуалом и показателями)

        if (_isSow)
            return;

        Instantiate(_replaceView, transform.position, transform.rotation, transform.parent)._isSow = true;
        Destroy(gameObject);
        _isSow = true;
    }
}
