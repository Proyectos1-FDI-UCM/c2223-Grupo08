using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoomComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.active = false;
        GameManager.Instance.nextRoom(GetComponentInParent<DoorComponent>());
        
    }   
}
