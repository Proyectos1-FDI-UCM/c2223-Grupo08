using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour
{
    #region references
    /// <summary>
    /// Prefab de la roca
    /// </summary>
    [SerializeField] private GameObject _object;

    /// <summary>
    /// El intervalo de tiempo entre rocas
    /// </summary>
    [SerializeField] private float _spawnInterval;
    #endregion

    #region properties
    /// <summary>
    /// El tiempo hasta la siguiente roca
    /// </summary>
    private float _timeToSpawn;
    #endregion

    private void Start()
    {
        _timeToSpawn = _spawnInterval;
    }
    void Update()
    {
        _timeToSpawn -= Time.deltaTime;

        if( _timeToSpawn < 0)
        {
            Instantiate(_object, transform);
            _timeToSpawn = _spawnInterval;
        }
    }
}
