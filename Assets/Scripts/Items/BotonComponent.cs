using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// El objeto que va a activar
    /// </summary>
    [SerializeField]
    private GameObject targetGameObject;
    #endregion

    #region properties
    /// <summary>
    /// Indica si esta activado
    /// </summary>
    private bool _activated = false;

    /// <summary>
    /// Referencia al animador
    /// </summary>
    private Animator _animator;
    #endregion

    #region methods
    /// <summary>
    /// Reinicia el boton y pasa a estar desactivado
    /// </summary>
    public void ResetBoton()
    {
        targetGameObject.SendMessage("DeactivateGameObject"); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
        _activated = false;

        _animator.SetBool("IsPressed", false);
    }
    #endregion

    private void Awake()
    {
        _animator= GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        targetGameObject.SendMessage("ActivateGameObject"); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
        _activated = true;

        _animator.SetBool("IsPressed", true);
    }
}
