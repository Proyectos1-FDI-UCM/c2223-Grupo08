using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SendMessageUpwards("Grounded");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SendMessageUpwards("NotGrounded");
    }
}
