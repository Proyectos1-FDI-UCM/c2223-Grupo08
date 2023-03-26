using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoomComponent : MonoBehaviour
{
    private int _count = 0;

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
