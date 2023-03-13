using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawComponent : MonoBehaviour
{
    [SerializeField]
    private Transform _startPoint;
    [SerializeField]
    private Transform _endPoint;
    [SerializeField]
    private float _velocity;

    private Vector2 minV;
    private Vector2 maxV;
    private Vector2 direction;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        transform.position = _startPoint.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        direction = (_endPoint.position - _startPoint.position).normalized;
        Debug.Log(direction);

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

    private void ResetObj()
    {
        direction = (_endPoint.position - _startPoint.position).normalized;
        _rigidbody.velocity = direction * _velocity;
    }
}
