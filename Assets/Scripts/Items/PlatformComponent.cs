using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject targetGameObject;    //El objeto que va a activar

    private bool _activated = false;
    private int _count = 0;

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
