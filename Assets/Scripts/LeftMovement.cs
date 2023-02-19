using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Transform _myTransform;
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform.position += Vector3.left * Time.deltaTime * _speed;
    }
}
