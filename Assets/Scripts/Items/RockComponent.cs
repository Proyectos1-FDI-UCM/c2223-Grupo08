using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockComponent : MonoBehaviour
{

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _anim.SetTrigger("Destruido");
        Invoke("Destruir", 1);
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }
}
