using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region references
    /// <summary>
    /// Transform del player
    /// </summary>
    [SerializeField] private Transform _playerTransform;

    /// <summary>
    /// El factor de seguimiento de la camara
    /// </summary>
    [SerializeField] private float _followFactor = 0.1f;

    /// <summary>
    /// El offset respecto al punto a mostrar
    /// </summary>
    [Space]
    [SerializeField] private Vector3 _offset;

    #endregion

    #region properties
    /// <summary>
    /// El punto a mostrar en pantalla
    /// </summary>
    private Vector2 _targetPos;
    #endregion

    #region methods
    /// <summary>
    /// Mueve la camara hacia una posicion dada con animacion
    /// </summary>
    /// <param name="target">Posicion a la que se quiere mover la camara</param>
    public void MoveCamera(Vector2 target)
    {
        _targetPos = new Vector3(target.x, target.y, _offset.z);
    }

    /// <summary>
    /// Pone la camara en una posicion dada sin animacion
    /// </summary>
    /// <param name="target">Posicion a la que se quiere mover la camara</param>
    public void setPosition(Vector2 target)
    {
        _targetPos = new Vector3(target.x, target.y, _offset.z);
        transform.position = _targetPos;
    }

    /// <summary>
    /// Actualiza la x de la posicion destino
    /// </summary>
    public void UpdateTargetPositionX()
    {
        _targetPos.x = _playerTransform.position.x + _offset.x;
    }

    /// <summary>
    /// Actualiza la y de la posicion destino
    /// </summary>
    public void UpdateTargetPositionY()
    {
        _targetPos.y = _playerTransform.position.y + _offset.y;
    }
    #endregion

    //Envia la camara hacia la posicion destino
    public void FixedUpdate()
    {
        Vector2 direccion = Vector2.Lerp(transform.position, _targetPos, _followFactor);

        if (Vector2.Distance(transform.position, _targetPos) > 0.15f || Vector2.Distance(transform.position, _targetPos) < -0.15f)    //Para si esta muy cerca del jugador
            transform.position = new Vector3(direccion.x, direccion.y, -10);
    }
}
