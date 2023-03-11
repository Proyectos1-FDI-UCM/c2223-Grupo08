using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    [SerializeField] private float _minSpawnInterval;

    [SerializeField] private float _maxSpawnInterval;

    private float _timeToSpawn;

    void Start()
    {
        _timeToSpawn = UnityEngine.Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    void Update()
    {
        _timeToSpawn -= Time.deltaTime;

        if( _timeToSpawn < 0)
        {
            Instantiate(_object, transform);
            _timeToSpawn = UnityEngine.Random.Range(_minSpawnInterval, _maxSpawnInterval);
        }
    }
}
