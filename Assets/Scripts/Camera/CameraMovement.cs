using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform _myTransform;
    private Transform _playerTransform;
    [SerializeField] private float _followFactor = 1.0f;
    [SerializeField] private float _offsetZ = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform= transform;
        _playerTransform= GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _myTransform.position = new Vector3(_playerTransform.position.x, _playerTransform.position.y, _playerTransform.position.z + _offsetZ) * _followFactor;
    }
}
