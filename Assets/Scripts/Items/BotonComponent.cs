using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject targetGameObject;    //El objeto que va a activar

    private bool _activated = false;

    private Animator _animator;
    private void Start()
    {
        _animator= GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        targetGameObject.SendMessage("ActivateGameObject"); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
        _activated = true;

        _animator.SetBool("IsPressed", true);
    }

    public void ResetBoton()
    {
        targetGameObject.SendMessage("DeactivateGameObject"); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
        _activated = false;

        _animator.SetBool("IsPressed", false);
    }
}
