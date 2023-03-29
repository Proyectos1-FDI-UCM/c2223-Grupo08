using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour
{
    private bool _isFirstTime = false;
    private CameraMovement CameraMovementComponent;
    [SerializeField]
    private CameraAreaScript _CameraArea;

    private Animator _animator;
    private BoxCollider2D _collider;

    private Vector2 DoorPosition;

    [SerializeField]
    private bool _isOpenFromBeginning = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider= GetComponent<BoxCollider2D>();
        CameraMovementComponent = Camera.main.GetComponent<CameraMovement>();
        DoorPosition = this.transform.position;
        if (_isOpenFromBeginning)
        {
            _isFirstTime = true;
            OpenDoor();
        }
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
        if (_isFirstTime == false)
        {
            CameraAnimToDoor();
        }
        _collider.enabled = false;
        _animator.SetBool("isOpen", true);
        _isFirstTime = true;
    }

    public void CloseDoor()
    {
        _collider.enabled = true;
        _animator.SetBool("isOpen", false);
    }

    public void CameraToDoor()
    {
        CameraMovementComponent.MoveCamera(DoorPosition);
        GameManager.Instance.IsShowingOpenDoor= true;
        PlayerManager.Instance.EnableInputs(false);
    }

    public void CameraReturnToPlayer()
    {
        CameraMovementComponent.MoveCamera(_CameraArea.ClosestPoint(PlayerManager.Instance.transform.position));
        GameManager.Instance.IsShowingOpenDoor = false;
        PlayerManager.Instance.EnableInputs(true);
    }

    private void CameraAnimToDoor()
    {
        CameraToDoor();
        Invoke("CameraReturnToPlayer", 2f);
    }
}
