using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Referencia al siguiente area de la camara
    /// </summary>
    [SerializeField]
    private CameraAreaScript _CameraArea;

    /// <summary>
    /// Indica si debe estar abierta desde el principio
    /// </summary>
    [SerializeField]
    private bool _isOpenFromBeginning = false;
    #endregion

    #region properties
    /// <summary>
    /// Indica si es la primera vez que se abre
    /// </summary>
    private bool _isFirstTime = false;

    /// <summary>
    /// Referencia al CameraMovement de la camara principal
    /// </summary>
    private CameraMovement CameraMovementComponent;

    /// <summary>
    /// Referencia al animador
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Referencia al collider2D de la puerta
    /// </summary>
    private BoxCollider2D _collider;

    /// <summary>
    /// La posicion de la puerta
    /// </summary>
    private Vector2 DoorPosition;
    #endregion

    #region methods

    //Eliminar activate y deactivate
    /// <summary>
    /// Abre la puerta
    /// </summary>
    private void ActivateGameObject()
    {
        OpenDoor();
    }

    /// <summary>
    /// Cierra la puerta
    /// </summary>
    private void DeactivateGameObject()
    {
        CloseDoor();
    }

    /// <summary>
    /// Vuelve a dejar la puerta como si fuera la primera vez que se abre
    /// </summary>
    public void resetFirstTime()
    {
        _isFirstTime = false;
    }

    /// <summary>
    /// Abre la puerta y si es la primera vez que se abre, hace una pequeña animacion
    /// </summary>
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

    /// <summary>
    /// Cierra la puerta
    /// </summary>
    public void CloseDoor()
    {
        _collider.enabled = true;
        _animator.SetBool("isOpen", false);
    }

    /// <summary>
    /// Redirige la camara a la puerta
    /// </summary>
    public void CameraToDoor()
    {
        CameraMovementComponent.MoveCamera(DoorPosition);
        GameManager.Instance.IsShowingOpenDoor = true;
        PlayerManager.Instance.EnableInputs(false);
    }

    /// <summary>
    /// Devuelve la camara al jugador
    /// </summary>
    public void CameraReturnToPlayer()
    {
        CameraMovementComponent.MoveCamera(_CameraArea.ClosestPoint(PlayerManager.Instance.transform.position));
        GameManager.Instance.IsShowingOpenDoor = false;
        PlayerManager.Instance.EnableInputs(true);
    }

    /// <summary>
    /// Manda la camara a la puerta y ,despues de un tiempo, la devuelve al jugador
    /// </summary>
    private void CameraAnimToDoor()
    {
        CameraToDoor();
        Invoke("CameraReturnToPlayer", 2f);
    }
    #endregion

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

}
