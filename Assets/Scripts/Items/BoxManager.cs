using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField]
    private int RequiredSize = 0;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void CheckBox(int size)
    {
        if (size < RequiredSize)
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
