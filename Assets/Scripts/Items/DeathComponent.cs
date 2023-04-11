using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slime" && PlayerManager.Instance.IsAlive())
        {
            PlayerManager.Instance.GetComponent<LiveComponent>().Death();
        }
    }
}