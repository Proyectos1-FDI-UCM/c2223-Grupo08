using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager.Instance.SendMessage("Muerte"); //Llama a la funcion del gameobject, tiene que tener una funcion con ese nombre para ser activado
    }

}