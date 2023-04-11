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
    private GameObject targetGameObject;
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

    //Cambiar el SendMessage por un OpenDoor y revisar tag
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "IgnoreAll")
        {
            if (!_activated)
            {
                targetGameObject.SendMessage("ActivateGameObject"); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
                _activated = true;
            }
            _count++;
        }
    }

    //Cambiar el SendMessage por un OpenDoor y revisar tag
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "IgnoreAll")
        {
            _count--;
            if(_count == 0)
            {
                targetGameObject.SendMessage("DeactivateGameObject"); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
                _activated = false;
            }
        }
    }
}
