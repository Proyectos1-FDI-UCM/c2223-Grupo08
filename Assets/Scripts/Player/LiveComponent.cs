using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveComponent : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Referencia al animador
    /// </summary>
    private Animator _animator;
    #endregion

    private void Start()
    {
        _animator= GetComponent<Animator>();
    }

    /// <summary>
    /// Mata al jugador
    /// </summary>
    // Mirar si se puede quitar el SendMessage
    public void Death ()
    {
        PlayerManager.Instance.SetAlive(false);
        PlayerManager.Instance.EnableInputs(false);
        PlayerManager.Instance.SendMessage("IsDeath", true);
        Invoke("PlayDeath", 1); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
    }

    /// <summary>
    /// Reinicia la sala
    /// </summary>
    // Mirar si se puede quitar la corutina
    private void PlayDeath()
    {
        StartCoroutine(GameManager.Instance.ResetRoom());
    }
}
