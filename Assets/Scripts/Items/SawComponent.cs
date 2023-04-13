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

    /// <summary>
    /// Ignora la condicion de X si esta en linea recta
    /// </summary>
    private bool _ignoreXAxys = false;

    /// <summary>
    /// Ignora la condicion de Y si esta en linea recta
    /// </summary>
    private bool _ignoreYAxys = false;

    /// <summary>
    /// Referencia al AudioSource
    /// </summary>
    private AudioSource _audioSource;
    #endregion

    #region methods
    /// <summary>
    /// Reinicia la sierra a su estado inicial
    /// </summary>
    public void ResetObj()
    {
        transform.position = _startPoint.position;
        direction = (_endPoint.position - _startPoint.position).normalized;
        _rigidbody.velocity = direction * _velocity;
    }
    
    /// <summary>
    /// Pausa el sonido
    /// </summary>
    public void PauseSound()
    {
        _audioSource.Pause();
    }
    
    /// <summary>
     /// Continua el sonido
     /// </summary>
    public void ResumeSound()
    {
        _audioSource.Play();
    }
    #endregion

    private void Awake()
    {
        transform.position = _startPoint.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        direction = (_endPoint.position - _startPoint.position).normalized;

        if (direction.x == 0)
        {
            _ignoreXAxys = true;
        }
        else if (direction.x > 0)
        {
            minV.x = _startPoint.position.x;
            maxV.x = _endPoint.position.x;
        }
        else
        {
            minV.x = _endPoint.position.x;
            maxV.x = _startPoint.position.x;
        }

        if (direction.y == 0)
        {
            _ignoreYAxys = true;
        }
        else if (direction.y > 0)
        {
            minV.y = _startPoint.position.y;
            maxV.y = _endPoint.position.y;
        }
        else
        {
            minV.y = _endPoint.position.y;
            maxV.y = _startPoint.position.y;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x < minV.x || transform.position.x > maxV.x || _ignoreXAxys)
        {
            if (transform.position.y < minV.y || transform.position.y > maxV.y || _ignoreYAxys)
                direction = -direction;
        }
        _rigidbody.velocity = direction * _velocity;
    }
}
