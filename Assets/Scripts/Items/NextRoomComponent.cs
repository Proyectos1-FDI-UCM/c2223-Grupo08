using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoomComponent : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Contador para asegurarse que no se activa 2 veces o mas
    /// </summary>
    private int _count = 0;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_count == 0)
        {
            gameObject.active = false;
            GameManager.Instance.nextRoom(GetComponentInParent<DoorComponent>());
            _count++;
        }
        
    }   
}
