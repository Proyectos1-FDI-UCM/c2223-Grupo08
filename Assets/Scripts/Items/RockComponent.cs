using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Tiempo de vida de la roca
    /// </summary>
    [SerializeField]
    private float time = 0.3f;

    #endregion

    #region properties
    /// <summary>
    /// Referencia al animador
    /// </summary>
    private Animator _anim;
    #endregion

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _anim.SetTrigger("Destruido");
        StartCoroutine(Destruir(time));
    }

    //Cambiarlo por solamente el destroy que permite pasarle segundos
    IEnumerator Destruir(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
