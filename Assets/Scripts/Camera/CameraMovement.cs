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

    public void MoveCamera(Vector2 target)
    {
        _targetPos = new Vector3(target.x, target.y, -10);
    }

    // Actualiza la x de la posicion destino
    public void UpdateTargetPositionX()
    {
         _targetPos.x = _playerTransform.position.x + _offset.x;
    }

    // Actualiza la y de la posicion destino
    public void UpdateTargetPositionY()
    {
        _targetPos.y = _playerTransform.position.y + _offset.y;
    }

    //Envia la camara hacia la posicion destino
    public void FixedUpdate()
    {
        Vector2 direccion = Vector2.Lerp(transform.position, _targetPos, _followFactor);

        if (Vector2.Distance(transform.position, _targetPos) > 0.15f || Vector2.Distance(transform.position, _targetPos) < -0.15f)    //Para si esta muy cerca del jugador
            transform.position = new Vector3(direccion.x, direccion.y, -10);
    }
}
