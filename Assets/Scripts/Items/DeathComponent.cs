using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    #region references
    [SerializeField]
    private LayerMask layer;
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layer && PlayerManager.Instance.IsAlive())
        {
            PlayerManager.Instance.GetComponent<LiveComponent>().Death();
        }
    }
}