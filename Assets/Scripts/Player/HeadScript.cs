using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    [SerializeField]
    private InputController _inputs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _inputs.StopJumping();
    }
}
