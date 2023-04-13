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
        if (((1<<collision.gameObject.layer) & layer.value) != 0 && PlayerManager.Instance.IsAlive())
        {
            PlayerManager.Instance.GetComponent<LiveComponent>().Death();
        }
    }
}