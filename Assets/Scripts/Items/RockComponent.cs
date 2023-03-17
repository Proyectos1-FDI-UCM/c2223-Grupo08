using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockComponent : MonoBehaviour
{

    private Animator _anim;
    private float time = 0.3f;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _anim.SetTrigger("Destruido");
        StartCoroutine(Destruir(time));
    }

    IEnumerator Destruir(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
