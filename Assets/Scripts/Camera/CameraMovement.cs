using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform _myTransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _followFactor = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform= transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direccion = Vector2.Lerp(_myTransform.position, _playerTransform.position, _followFactor);
        if (direccion.magnitude > 0.15f)    //Para si esta muy cerca del jugador
            _myTransform.position =new Vector3(direccion.x, direccion.y,-10);
    }
}
