using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    #region references
    /// <summary>
    /// Referencia al InputController del jugador
    /// </summary>
    [SerializeField]
    private InputController _inputs;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _inputs.StopJumping();
    }
}
