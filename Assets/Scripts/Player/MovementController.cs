using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 0.3f; // Valor de la fuerza del salto

    [SerializeField]
    private float _velocity = 5;    // Valor con el que se moverá en el eje X

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void MoveRight(bool isGrounded = false)
    {
        float y = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2(_velocity, y);
    }

    private void MoveLeft(bool isGrounded = false)
    {
        float y = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2(-_velocity, y);
    }
}
