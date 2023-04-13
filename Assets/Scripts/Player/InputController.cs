using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    #region references
    /// <summary>
    /// Valor inicial del contador entre frames
    /// </summary>
    [SerializeField]
    private float _frameTime = 0.1f;
    /// <summary>
    /// Valor inicial del contador de salto
    /// </summary>
    [SerializeField]
    private float _jumpTime = 0.3f;
    #endregion

    #region properties
    /// <summary>
    /// Indica si a caido al suelo
    /// </summary>
    private bool _isGrounded = true;

    /// <summary>
    /// Referencia al MovementController del jugador
    /// </summary>
    private MovementController _movementController;

    /// <summary>
    /// Referencia al AudioSource
    /// </summary>
    private AudioSource _audioSource;

    /// <summary>
    /// Sonido al saltar
    /// </summary>
    private AudioClip _jumpAudio;

    /// <summary>
    /// Sonido al moverse
    /// </summary>
    private AudioClip _walkAudio;

    /// <summary>
    /// Indica si esta en la accion de saltar
    /// </summary>
    private bool _isJumping = false;

    /// <summary>
    /// Contador para el tiempo en el aire
    /// </summary>
    private float _jumpTimeCounter = 0f;

    /// <summary>
    /// Contador para el tiempo entre frames
    /// </summary>
    private float _frameTimeCounter = 0;
    #endregion

    #region methods
    /// <summary>
    /// Para de saltar
    /// </summary>
    public void StopJumping()
    {
        _isJumping = false;
    }

    /// <summary>
    /// Esta en el suelo
    /// </summary>
    /// <param name="b">Si esta en el suelo o no</param>
    public void Grounded(bool b)
    {
        _isGrounded = b;
    }

    /// <summary>
    /// Para el sonido
    /// </summary>
    public void StopSound()
    {
        _audioSource.Stop();
    }
    #endregion

    void Start()
    {
        _movementController = GetComponent<MovementController>();
        _audioSource = GetComponent<AudioSource>();
        _jumpAudio = GameManager.Instance.GetSoundClip(Audios.Jump);
        _walkAudio = GameManager.Instance.GetSoundClip(Audios.Jump);
    }

    // Update is called once per frame
    void Update()
    {
        //Da un impulso inicia e inicializa el contador en el aire
        if (Input.GetKeyDown(ConfigScript.ButtonsCodes[Buttons.Jump]) && _isGrounded) {
            _isJumping = true;
            _jumpTimeCounter = _jumpTime;
           _movementController.Jump();
            _frameTimeCounter = _frameTime;
            _audioSource.clip = _jumpAudio;
            _audioSource.loop = false;
            _audioSource.Play();
        }
        //Aumenta el salto hasta cierto tiempo
        else if (Input.GetKey(ConfigScript.ButtonsCodes[Buttons.Jump]) && _isJumping) {
            if (_frameTimeCounter < 0) {
                if (_jumpTimeCounter > 0)
                {
                    _movementController.Jump(); ;
                    _jumpTimeCounter -= _frameTime;
                    _frameTimeCounter += _frameTime;
                }
                else
                {
                    _isJumping = false;
                }
            }
            else
            {
                _frameTimeCounter -= Time.deltaTime;
            }
        }
        // En caso de levantar la tecla, impide volver a conseguir el impulso
        else if (Input.GetKeyUp(ConfigScript.ButtonsCodes[Buttons.Jump]))
        {
            _isJumping = false;
        }

        if(Input.GetKey(ConfigScript.ButtonsCodes[Buttons.Right]))
        {
            if(!_audioSource.isPlaying && _isGrounded)
            {
                _audioSource.clip = _walkAudio;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            _movementController.MoveRight();
        }
        else if(Input.GetKey(ConfigScript.ButtonsCodes[Buttons.Left]))
        {
            if (!_audioSource.isPlaying && _isGrounded)
            {
                _audioSource.clip = _walkAudio;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            _movementController.MoveLeft();
        }
        if (Input.GetKeyUp(ConfigScript.ButtonsCodes[Buttons.Left])|| Input.GetKeyUp(ConfigScript.ButtonsCodes[Buttons.Right]))
        {
            _movementController.StopMoving();
            if(_audioSource.clip == _walkAudio)
            {
                _audioSource.Stop();
            }
        }

        if (Input.GetKey(ConfigScript.ButtonsCodes[Buttons.Drop]))
        {
            PlayerManager.Instance.resetSize();
        }

        if (Input.GetKey(ConfigScript.ButtonsCodes[Buttons.Reset]))
        {
            GameManager.Instance.FadeOut();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.isPaused)
        {
            MenusManager.PauseGame();
        }
    }
}
