using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static private PlayerManager _instance;   //Instancia del manager
    static public PlayerManager Instance { get { return _instance; } }

    [SerializeField]
    private Transform[] _spawns;

    private MovementController _movementController;
    private PlayerAnimator _playerAnimator;
    private bool _isAlive = true;
    private int _PlayerSize = 0;    //Indica el tamaño del jugador

    public int getSize() { return _PlayerSize; } //Devuelve el tamaño del jugador

    public bool IsAlive() { return _isAlive; }
    public void SetAlive(bool b) { _isAlive = b; }

    public Vector2 getSpawnPoint(int n) { return _spawns[n].position; }

    public ParticleSystem particles;

    private void Awake()
    {
        _instance = this;
        _movementController = GetComponent<MovementController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    //Aumenta en 1 el tamaño
    public void incrementSize()
    {
        _PlayerSize++;
        transform.localScale += new  Vector3(0.2f,0.2f,0);
        GameManager.Instance.CheckBoxes(_PlayerSize);
        _movementController.SetSlowFactor(_PlayerSize);
        _movementController.SetJumpFactor(_PlayerSize);
        GameManager.Instance.UpdateCounter(_PlayerSize);
    }

    //Devuelve el tamaño a 0
    public void resetSize()
    { 
        if(_PlayerSize > 0)
        {
            particles.Play();
            _PlayerSize = 0;
            transform.localScale = Vector3.one;
            GameManager.Instance.CheckBoxes(_PlayerSize);
            _movementController.SetSlowFactor(_PlayerSize);
            _movementController.SetJumpFactor(_PlayerSize);
            GameManager.Instance.UpdateCounter(_PlayerSize);
        }


    }

    //Devuelve al jugador a su posicion inicial en esa sala
    public void goToSpawn(int room)
    {
        transform.position = _spawns[room].position;
    }

    //Quita los inputs del jugador
    public void EnableInputs(bool enabled)
    {
        gameObject.GetComponent<InputController>().enabled = enabled;
    }

    public void moveToNextRoom(int currentRoom, Vector2 cameraPoint, DoorComponent door)
    {
        StartCoroutine(_playerAnimator.nextRoomAnim(_spawns[currentRoom].position,cameraPoint, door));
    }
}
