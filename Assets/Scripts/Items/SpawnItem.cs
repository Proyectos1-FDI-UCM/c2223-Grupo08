using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    private GameObject _obj;

    public void Spawn()
    {
        if(_obj == null)
            _obj = Instantiate(_object, transform);
    }

    public void Delete()
    {
        if (_obj != null)
            Destroy(_obj);
    }

    public void ResetObj()
    {
        if (_obj != null)
        {
            _obj.transform.position = transform.position;
        }
        else
        {
            Spawn();
        }
    }
}
