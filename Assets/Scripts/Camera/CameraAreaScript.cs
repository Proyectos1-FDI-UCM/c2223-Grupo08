using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAreaScript : MonoBehaviour
{
    [TextArea]
    [Tooltip("No hace nada, solo es un comentario.")]
    public string Notes = "Poner a 7 tiles de distancia de las paredes verticales para no ver a traves de ellas.";

    private Collider2D m_Collider;
    private CameraMovement _cameraMovement;
    private Transform _playerTransform;

    private void Awake()
    {
        m_Collider = GetComponent<Collider2D>();
        _cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    private void Start()
    {
        _playerTransform = PlayerManager.Instance.gameObject.transform;
    }

    //Actualiza la camara si esta en los limites pero separando los limites de x e y
    void FixedUpdate()
    {
        if (m_Collider.bounds.min.x < _playerTransform.position.x && m_Collider.bounds.max.x > _playerTransform.position.x)
        {
            _cameraMovement.UpdateTargetPositionX();
        }
        if (m_Collider.bounds.min.y < _playerTransform.position.y && m_Collider.bounds.max.y > _playerTransform.position.y)
        {
            _cameraMovement.UpdateTargetPositionY();
        }
    }

    public Vector2 ClosestPoint(Vector2 point)
    {
        return m_Collider.bounds.ClosestPoint(point);
    }
}
