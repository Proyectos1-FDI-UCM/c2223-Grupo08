using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 0.7f;
 
    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Movement(int velocity)
    {
        float y = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2 (velocity,y);
    }
}
