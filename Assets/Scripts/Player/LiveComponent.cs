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

    private void Death ()
    {
        StartCoroutine(GameManager.Instance.ResetRoom());
    }
}
