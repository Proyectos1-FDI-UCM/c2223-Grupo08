using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    #region references
    /// <summary>
    /// Valor de la fuerza del salto
    /// </summary>
    [SerializeField]
    private float _jumpForce = 3.5f;

    /// <summary>
    /// Valor maximo con el que se moverá en el eje X
    /// </summary>
    [SerializeField]
    private float _maxVelocity = 5;

    /// <summary>
    /// Aceleracion con el que se moverá en el eje X
    /// </summary>
    [SerializeField]
    private float _acceleration = 0f;

    /// <summary>
    /// Penalización por tamaño en el movimiento
    /// </summary>
    [SerializeField]
    private float _slowPenalty = 0.5f;

    /// <summary>
    ///  Penalización por tamaño en el salto
    /// </summary>
    [SerializeField]
    private float _jumpPenalty = 0.25f;

    [SerializeField]
    private AudioClip _WalkAudio;
    #endregion

    #region properties
    /// <summary>
    /// Factor de ralentizado al moverse
    /// </summary>
    private float _slowFactor = 0;

    /// <summary>
    /// Factor de penalizacion de salto
    /// </summary>
    private float _jumpFactor = 0;

    /// <summary>
    /// Referencia al RigidBody2D
    /// </summary>
    private Rigidbody2D _rigidbody2D;

    public float getSlowFactor() { return _slowFactor; }

    /// <summary>
    /// Actualiza el factor de ralentizado al moverse
    /// </summary>
    /// <param name="size">Tamaño del juagdor</param>
    public void SetSlowFactor(float size)
    {
        _slowFactor = _slowPenalty * size;
    }

    /// <summary>
    /// Actualiza el factor de penalizacion de salto
    /// </summary>
    /// <param name="size">Tamaño del juagor</param>
    public void SetJumpFactor(float size)
    {
        _jumpFactor = _jumpPenalty * size;
    }

    /// <summary>
    /// Referencia al AudioSource
    /// </summary>
    private AudioSource _audioSource;
    #endregion

    #region methods

    /// <summary>
    /// Hace saltar al jugador
    /// </summary>
    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * (_jumpForce - _jumpFactor), ForceMode2D.Impulse);
    }

    /// <summary>
    /// Mueve a la derecha al juagdor
    /// </summary>
    public void MoveRight()
    {
        if (_maxVelocity - _slowFactor > _acceleration)
        {
            _acceleration += _maxVelocity * Time.deltaTime;
            float y = _rigidbody2D.velocity.y;
            _rigidbody2D.velocity = new Vector2(_acceleration, y);
        }
        else
        {
            float y = _rigidbody2D.velocity.y;
            _rigidbody2D.velocity = new Vector2(_maxVelocity - _slowFactor, y);
        }
        _audioSource.clip = _WalkAudio;
        _audioSource.Play();
    }

    /// <summary>
    /// Mueve a la izquierda al juagdor
    /// </summary>
    public void MoveLeft()
    {
        if (-(_maxVelocity - _slowFactor) < _acceleration)
        {
            _acceleration -= _maxVelocity * Time.deltaTime;
            float y = _rigidbody2D.velocity.y;
            _rigidbody2D.velocity = new Vector2(_acceleration, y);
        }
        else
        {
            float y = _rigidbody2D.velocity.y;
            _rigidbody2D.velocity = new Vector2(-(_maxVelocity - _slowFactor), y);
        }
        _audioSource.clip = _WalkAudio;
        _audioSource.Play();
    }

    /// <summary>
    /// Para al juagdor en el eje x
    /// </summary>
    public void StopMoving()
    {
        _acceleration = 0;
    }
    #endregion

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

}
