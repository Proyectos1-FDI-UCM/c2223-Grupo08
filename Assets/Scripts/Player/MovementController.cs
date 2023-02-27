using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 3.5f; // Valor de la fuerza del salto

    [SerializeField]
    private float _velocity = 5;    // Valor con el que se moverá en el eje X

    [SerializeField]
    private float _slowPenalty = 0.5f;

    [SerializeField]
    private float _jumpPenalty = 0.5f;

    private float _slowFactor = 0;

    private float _jumpFactor = 0;

    private Rigidbody2D _rigidbody2D;

    public float getSlowFactor() { return _slowFactor; }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * (_jumpForce - _jumpFactor), ForceMode2D.Impulse);
    }

    private void MoveRight(bool isGrounded = false)
    {
        float y = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2(_velocity - _slowFactor, y);
    }

    private void MoveLeft(bool isGrounded = false)
    {
        float y = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2(-(_velocity - _slowFactor), y);
    }

    public void SetSlowFactor(float size) {
        _slowFactor = _slowPenalty * size;
    }
    public void SetJumpFactor(float size)
    {
        _jumpFactor = _jumpPenalty * size;
    }
}
