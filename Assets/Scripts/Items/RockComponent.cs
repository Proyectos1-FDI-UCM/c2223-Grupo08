using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockComponent : MonoBehaviour
{
    private AudioSource _audioRock;
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
        _audioRock = GetComponent<AudioSource>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audioRock.Play();
        _anim.SetTrigger("Destruido");
        Destroy(gameObject, time);
    }
}
