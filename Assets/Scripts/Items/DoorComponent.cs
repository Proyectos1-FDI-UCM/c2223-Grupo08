using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;
    [SerializeField]
    private CameraMovement CameraMovementComponent;

    private Animator _animator;
    private BoxCollider2D _collider;

    private Vector2 DoorPosition;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider= GetComponent<BoxCollider2D>();
        CameraMovementComponent = Camera.main.GetComponent<CameraMovement>();
        DoorPosition = this.transform.position;
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
        if (_isOpen == false)
        {
            CameraAnimToDoor();
        }
        _collider.enabled = false;
        _animator.SetBool("isOpen", true);
        _isOpen = true;
    }

    public void CloseDoor()
    {
        _collider.enabled = true;
        _animator.SetBool("isOpen", false);
        _isOpen = false;
    }

    public void CamaraToDoor()
    {
        CameraMovementComponent.MoveCamera(DoorPosition);
        GameManager.Instance.IsShowingOpenDoor= true;
    }

    public void CameraReturnToPlayer()
    {
        CameraMovementComponent.MoveCamera(PlayerManager.Instance.transform.position);
        GameManager.Instance.IsShowingOpenDoor = false;
    }

    private void CameraAnimToDoor()
    {
        CamaraToDoor();
        Invoke("CameraReturnToPlayer", 2f);
    }
}
