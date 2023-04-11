using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Punto de inicio de la ruta a seguir
    /// </summary>
    [SerializeField]
    private Transform _startPoint;
    /// <summary>
    /// El punto final de la ruta a seguir
    /// </summary>
    [SerializeField]
    private Transform _endPoint;

    /// <summary>
    /// Velocidad de la sierra
    /// </summary>
    [SerializeField]
    private float _velocity;
    #endregion

    #region properties
    /// <summary>
    /// Punto minimo del vector de direccion
    /// </summary>
    private Vector2 minV;

    /// <summary>
    /// Punto maximo del vector de direccion
    /// </summary>
    private Vector2 maxV;

    /// <summary>
    /// Vector de direccion normalizado
    /// </summary>
    private Vector2 direction;

    /// <summary>
    /// Referencia al rigidbody de la sierra
    /// </summary>
    private Rigidbody2D _rigidbody;
    #endregion

    #region methods
    /// <summary>
    /// Reinicia la sierra a su estado inicial
    /// </summary>
    public void ResetObj()
    {
        direction = (_endPoint.position - _startPoint.position).normalized;
        _rigidbody.velocity = direction * _velocity;
    }
    #endregion

    private void Start()
    {
        transform.position = _startPoint.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        direction = (_endPoint.position - _startPoint.position).normalized;

        if (direction.x >= 0)
        {
            minV.x = _startPoint.position.x;
            maxV.x = _endPoint.position.x;
        }
        else
        {
            minV.x = _endPoint.position.x;
            maxV.x = _startPoint.position.x;
        }

        if (direction.y >= 0)
        {
            minV.y = _startPoint.position.y;
            maxV.y = _endPoint.position.y;
        }
        {
            minV.y = _endPoint.position.y;
            maxV.y = _startPoint.position.y;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x < minV.x || transform.position.x > maxV.x)
        {
            if (transform.position.y < minV.y || transform.position.y > maxV.y)
                direction = -direction;
        }

        _rigidbody.velocity = direction * _velocity;
    }
}
