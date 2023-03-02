using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerManager.Instance.EnableInputs(false);
        PlayerManager.Instance.SendMessage("IsDeath", true);
        Invoke("PlayDeath", 1); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
    }

    private void PlayDeath(){
        PlayerManager.Instance.SendMessage("Death");
    }
}