using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// El tamaño requerido para desbloquear la caja
    /// </summary>
    [SerializeField]
    private int RequiredSize = 0;
    #endregion
    #region properties
    /// <summary>
    /// Referencia al rigidbody2D de la caja
    /// </summary>
    private Rigidbody2D _rigidbody2D;

    /// <summary>
    /// Referencia al audioSource de la caja
    /// </summary>
    private AudioSource _audioSource;
    #endregion

    #region methods
    /// <summary>
    /// Comprueba segun un tamaño dado si tiene el tamaño requerido para desbloquear la caja
    /// </summary>
    /// <param name="size">El tamaño a comprobar</param>
    public void CheckBox(int size)
    {
        if (size < RequiredSize)
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    #endregion
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_rigidbody2D.velocity.x != 0 && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        else if(_rigidbody2D.velocity.x == 0 && _audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }
}
