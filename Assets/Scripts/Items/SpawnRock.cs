using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    [SerializeField] private float _spawnInterval;

    private float _timeToSpawn;

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
