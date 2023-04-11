using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAreaScript : MonoBehaviour
{
    #region properties
    [TextArea]
    [Tooltip("No hace nada, solo es un comentario.")]
    public string Notes = "Poner a 7 tiles de distancia de las paredes verticales para no ver a traves de ellas.";

    /// <summary>
    /// Collider de este gameobject
    /// </summary>
    private Collider2D m_Collider;

    /// <summary>
    /// Referencia a la camera movement de la main camera
    /// </summary>
    private CameraMovement _cameraMovement;

    /// <summary>
    /// El transform del player
    /// </summary>
    private Transform _playerTransform;
    #endregion

    #region methods
    /// <summary>
    /// Encuentra el punto mas cercano al area de uno dado
    /// </summary>
    /// <param name="point">El punto ha encontrar</param>
    /// <returns>El punto mas cercano a este area</returns>
    public Vector2 ClosestPoint(Vector2 point)
    {
        return m_Collider.bounds.ClosestPoint(point);
    }
    #endregion

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
        if (m_Collider.bounds.min.x < _playerTransform.position.x && m_Collider.bounds.max.x > _playerTransform.position.x && GameManager.Instance.IsShowingOpenDoor == false)
        {
            _cameraMovement.UpdateTargetPositionX();
        }
        if (m_Collider.bounds.min.y < _playerTransform.position.y && m_Collider.bounds.max.y > _playerTransform.position.y && GameManager.Instance.IsShowingOpenDoor == false)
        {
            _cameraMovement.UpdateTargetPositionY();
        }
    }
}
