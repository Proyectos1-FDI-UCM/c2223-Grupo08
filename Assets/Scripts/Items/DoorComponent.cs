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
    /// Indica si esta abierta
    /// </summary>
    [SerializeField]
    private bool _isOpen = false;
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

    /// <summary>
    /// Referencia al AudioSource
    /// </summary>
    private AudioSource _audioSource;

    /// <summary>
    /// Sonido al abrirse la puerta
    /// </summary>
    private AudioClip _openDoorAudio;

    /// <summary>
    /// Sonido al cerrarse la puerta
    /// </summary>
    private AudioClip _closeDoorAudio;
    #endregion

    #region methods

    /// <summary>
    /// Vuelve a dejar la puerta como si fuera la primera vez que se abre
    /// </summary>
    public void resetFirstTime()
    {
        _isFirstTime = false;
        CloseDoor(false);
    }

    /// <summary>
    /// Abre la puerta y si es la primera vez que se abre, hace una pequeña animacion
    /// </summary>
    /// <param name="playSound">Si se quiere reproducir el sonido o no</param>
    public void OpenDoor(bool playSound = true)
    {
        if (!_isOpen)
        {
            if (_isFirstTime == false)
            {
                PlayerManager.Instance.StopSounds();
                CameraAnimToDoor();
            }
            _collider.enabled = false;
            _animator.SetBool("isOpen", true);
            _isFirstTime = true;
            if (playSound)
            {
                _audioSource.clip = _openDoorAudio;
                _audioSource.Play();
            }
            _isOpen = true;
        }
    }

    /// <summary>
    /// Cierra la puerta
    /// </summary>
    /// <param name="playSound">Si se quiere reproducir el sonido o no</param>
    public void CloseDoor(bool playSound = true)
    {
        if (_isOpen) {
            _collider.enabled = true;
            _animator.SetBool("isOpen", false);
            if (playSound)
            {
                _audioSource.clip = _closeDoorAudio;
                _audioSource.Play();
            }
            _isOpen = false;
        }
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

    /// <summary>
    /// Pausa el sonido
    /// </summary>
    public void PauseSound()
    {
        _audioSource.Pause();
    }

    /// <summary>
    /// Pausa el sonido
    /// </summary>
    public void ResumeSound()
    {
        _audioSource.Play();
    }
    #endregion

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider= GetComponent<BoxCollider2D>();
        CameraMovementComponent = Camera.main.GetComponent<CameraMovement>();
        _audioSource= GetComponent<AudioSource>();
        DoorPosition = this.transform.position;
        if (_isOpen)
        {
            _isFirstTime = true;
            OpenDoor();
        }
    }

    private void Start()
    {
        _openDoorAudio = GameManager.Instance.GetSoundClip(Audios.DoorOpen);
        _closeDoorAudio = GameManager.Instance.GetSoundClip(Audios.DoorClosed);
    }
}
