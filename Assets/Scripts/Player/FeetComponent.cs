using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetComponent : MonoBehaviour
{
    private int _count = 0;

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
