using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 3.5f; // Valor de la fuerza del salto

    [SerializeField]
    private float _maxVelocity = 5;    // Valor maximo con el que se moverá en el eje X

    [SerializeField]
    private float _acceleration = 0f;    // Aceleracion con el que se moverá en el eje X

    [SerializeField]
    private float _slowPenalty = 0.5f;  // Penalización por tamaño en el movimiento

    [SerializeField]
    private float _jumpPenalty = 0.25f; // Penalización por tamaño en el salto

    private float _slowFactor = 0;

    private float _jumpFactor = 0;

    private Rigidbody2D _rigidbody2D;

    public float getSlowFactor() { return _slowFactor; }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * (_jumpForce - _jumpFactor), ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        if (_maxVelocity - _slowFactor > _acceleration)
        {
            _acceleration += _maxVelocity * Time.deltaTime;
            float y = _rigidbody2D.velocity.y;
            Debug.Log(y);
            _rigidbody2D.velocity = new Vector2(_acceleration, y);
        }
        else
        {
            float y = _rigidbody2D.velocity.y;
            _rigidbody2D.velocity = new Vector2(_maxVelocity - _slowFactor, y);
        }
    }

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
    }
    public void StopMoving()
    {
        _acceleration = 0;
    }

    public void SetSlowFactor(float size) {
        _slowFactor = _slowPenalty * size;
    }
    public void SetJumpFactor(float size)
    {
        _jumpFactor = _jumpPenalty * size;
    }
}
