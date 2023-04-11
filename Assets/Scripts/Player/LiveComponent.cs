using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveComponent : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator= GetComponent<Animator>();
    }

    public void Death ()
    {
        PlayerManager.Instance.SetAlive(false);
        PlayerManager.Instance.EnableInputs(false);
        PlayerManager.Instance.SendMessage("IsDeath", true);
        Invoke("PlayDeath", 1); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
    }

    private void PlayDeath()
    {
        StartCoroutine(GameManager.Instance.ResetRoom());
    }
}
