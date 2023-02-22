using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject targetGameObject;    //El objeto que va a activar

    private bool _activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targetGameObject.SendMessage("ActivateGameObject"); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
        _activated = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_activated)  //De momento solo lee el personaje, se tiene que mejorar
        {
            targetGameObject.SendMessage("DeactivateGameObject"); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
            _activated = false;
        }
    }
}
