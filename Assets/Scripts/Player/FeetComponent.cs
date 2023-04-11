using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetComponent : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Contador para asegurarse que no se activa 2 veces o mas
    /// </summary>
    private int _count = 0;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "IgnoreAll") {
            if (_count == 0)
            {
                SendMessageUpwards("Grounded");
            }
            _count++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "IgnoreAll")
        {
            _count--;
            if (_count == 0) {
                SendMessageUpwards("NotGrounded"); 
            }
        }
    }
}
