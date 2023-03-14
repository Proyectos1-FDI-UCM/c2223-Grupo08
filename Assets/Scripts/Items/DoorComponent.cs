using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;

    private Animator _animator;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider= GetComponent<BoxCollider2D>();
    }

    private void ActivateGameObject()
    {
        OpenDoor();
    }
    private void DeactivateGameObject()
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        _collider.enabled = false;
        _animator.SetBool("isOpen", true);
        _isOpen= true;
    }

    public void CloseDoor()
    {
        _collider.enabled = true;
        _animator.SetBool("isOpen", false);
        _isOpen = false;
    }
}
