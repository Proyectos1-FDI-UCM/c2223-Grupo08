using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _followFactor = 0.1f;

    // Update is called once per frame
    public void UpdateCamera()
    {
        Vector2 direccion = Vector2.Lerp(transform.position, _playerTransform.position, _followFactor);

        if (direccion.magnitude > 0.15f || direccion.magnitude > -0.15f)    //Para si esta muy cerca del jugador
            transform.position =new Vector3(direccion.x, direccion.y,-10);
    }
}
