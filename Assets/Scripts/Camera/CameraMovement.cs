using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _followFactor = 0.1f;
    [Space]
    [SerializeField] private Vector3 _offset;
    private Vector2 _targetPos;

    public void UpdateTargetPositionX()
    {
         _targetPos.x = _playerTransform.position.x + _offset.x;
    }

    public void UpdateTargetPositionY()
    {
        _targetPos.y = _playerTransform.position.y + _offset.y;
    }

    public void FixedUpdate()
    {
        Vector2 direccion = Vector2.Lerp(transform.position, _targetPos, _followFactor);

        if (direccion.magnitude > 0.15f || direccion.magnitude > -0.15f)    //Para si esta muy cerca del jugador
            transform.position = new Vector3(direccion.x, direccion.y, -10);
    }
}
