using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Referencia al objeto que va a activar
    /// </summary>
    [SerializeField]
    private DoorComponent targetDoor;
    #endregion

    #region properties
    /// <summary>
    /// Indica si esta activado el objeto
    /// </summary>
    private bool _activated = false;

    /// <summary>
    /// Contador para saber si siguen habiendo cosas en el objeto
    /// </summary>
    private int _count = 0;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_activated)
        {
            targetDoor.OpenDoor();
            _activated = true;
        }
        _count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _count--;
        if(_count == 0)
        {
            targetDoor.CloseDoor();
            _activated = false;
        }
    }
}
