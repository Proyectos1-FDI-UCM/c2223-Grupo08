using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    #region references
    /// <summary>
    /// Referencia al prefab del objeto a instanciar
    /// </summary>
    [SerializeField] private GameObject _object;
    #endregion

    #region properties
    /// <summary>
    /// Referencia del objeto instanciado
    /// </summary>
    private GameObject _obj;
    #endregion

    #region methods

    /// <summary>
    /// Instancia el prefab
    /// </summary>
    public void Spawn()
    {
        if(_obj == null)
            _obj = Instantiate(_object, transform);
    }

    /// <summary>
    /// Destruye el objeto instanciado
    /// </summary>
    public void Delete()
    {
        if (_obj != null)
            Destroy(_obj);
    }

    /// <summary>
    /// Devueve el objeto a su posicion inicial si existe y si no lo instancia
    /// </summary>
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
    #endregion
}
