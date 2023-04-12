using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Array con los puntos de spawn del player
    /// </summary>
    [SerializeField]
    private Transform[] _spawns;
    #endregion

    #region properties
    /// <summary>
    /// Instancia del PlayerManager
    /// </summary>
    static private PlayerManager _instance;

    /// <summary>
    /// Get de la instancia del PlayerManager
    /// </summary>
    static public PlayerManager Instance { get { return _instance; } }

    /// <summary>
    /// Referencia al MovementController
    /// </summary>
    private MovementController _movementController;

    /// <summary>
    /// Referencia al PlayerAnimator
    /// </summary>
    private PlayerAnimator _playerAnimator;

    /// <summary>
    /// Referencia al inputController
    /// </summary>
    private InputController _inputController;

    /// <summary>
    /// Indica si esta vivo el jugador
    /// </summary>
    private bool _isAlive = true;

    /// <summary>
    /// Indica el tamaño del jugador
    /// </summary>
    private int _PlayerSize = 0;

    public int getSize() { return _PlayerSize; } //Devuelve el tamaño del jugador

    public bool IsAlive() { return _isAlive; }
    public void SetAlive(bool b) { _isAlive = b; }

    /// <summary>
    /// Devuelve el punto de spawn en esa sala
    /// </summary>
    /// <param name="n">Numero de la sala</param>
    /// <returns>El punto de spawn en esa sala</returns>
    public Vector2 getSpawnPoint(int n) { return _spawns[n].position; }

    /// <summary>
    /// Referencia al ParticleSystem
    /// </summary>
    public ParticleSystem particles;
    #endregion

    #region methods
    /// <summary>
    /// Aumenta en 1 el tamaño
    /// </summary>
    public void incrementSize()
    {
        _PlayerSize++;
        transform.localScale += new Vector3(Mathf.Sign(transform.localScale.x) * 0.2f, 0.2f, 0);
        GameManager.Instance.CheckBoxes(_PlayerSize);
        _movementController.SetSlowFactor(_PlayerSize);
        _movementController.SetJumpFactor(_PlayerSize);
        GameManager.Instance.ResizeBallsBar(_PlayerSize);
    }

    /// <summary>
    /// Devuelve el tamaño a 0
    /// </summary>
    public void resetSize()
    {
        if (_PlayerSize > 0)
        {
            particles.Play();
            _PlayerSize = 0;
            transform.localScale = new Vector3(Mathf.Sign(transform.localScale.x), 1, 0);
            GameManager.Instance.CheckBoxes(_PlayerSize);
            _movementController.SetSlowFactor(_PlayerSize);
            _movementController.SetJumpFactor(_PlayerSize);
            GameManager.Instance.ResizeBallsBar(_PlayerSize);
        }


    }

    /// <summary>
    /// Devuelve al jugador a su posicion inicial en esa sala
    /// </summary>
    /// <param name="room">Sala actual</param>
    public void goToSpawn(int room)
    {
        transform.position = _spawns[room].position;
    }

    /// <summary>
    /// Quita o pone los inputs del jugador
    /// </summary>
    /// <param name="enabled">Si estan activos o no</param>
    public void EnableInputs(bool enabled)
    {
        _inputController.enabled = enabled;
        if (!enabled)
            _movementController.StopMoving();
    }

    /// <summary>
    /// Mueve al personaje a la siguiente sala
    /// </summary>
    /// <param name="currentRoom">Sala actual</param>
    /// <param name="cameraPoint">Punto final de la camara</param>
    /// <param name="door">Puerta que realiza la accion</param>
    public void moveToNextRoom(int currentRoom, Vector2 cameraPoint, DoorComponent door)
    {
        _playerAnimator.playNextRoomAnim(_spawns[currentRoom].position, cameraPoint, door);
    }

    /// <summary>
    /// Cambia el jugador a en el suelo(true) o en el aire(false)
    /// </summary>
    /// <param name="b">Indica si esta en el suelo o no</param>
    public void SetGrounded(bool b){
        _playerAnimator.Grounded(b);
        _inputController.Grounded(b);
    }

    #endregion

    private void Awake()
    {
        _instance = this;
        _movementController = GetComponent<MovementController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _inputController = GetComponent<InputController>();
    }
}
