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
        if (m_Collider.bounds.Contains(_playerTransform.position))
        {
            Debug.Log("a");
            _cameraMovement.UpdateCamera();
        }
    }
}
