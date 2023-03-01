using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAreaScript : MonoBehaviour
{
    private Collider2D m_Collider;
    private CameraMovement _cameraMovement;
    private Transform _playerTransform;

    private void Start()
    {
        m_Collider = GetComponent<Collider2D>();
        _cameraMovement = Camera.main.GetComponent<CameraMovement>();
        _playerTransform = PlayerManager.Instance.gameObject.transform;
    }

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
}
