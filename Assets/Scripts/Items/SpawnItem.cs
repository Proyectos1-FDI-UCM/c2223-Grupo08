using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    private Transform _spawnTransform;

    // Start is called before the first frame update
    void Start()
    {
        _spawnTransform = transform;

        Instantiate(_object, _spawnTransform);
    }

    public void Spawn()
    {
        Instantiate(_object, _spawnTransform);

    }


    
}
