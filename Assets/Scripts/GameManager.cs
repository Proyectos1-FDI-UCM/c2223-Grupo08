using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    # region references
    /// <summary>
    /// UI manager del juego
    /// </summary>
    [SerializeField]
    private UIManager _uiManager;

    /// <summary>
    /// Los frames a los que corre el juego
    /// </summary>
    [SerializeField]
    private int targetFrameRate = 120;

    /// <summary>
    /// Gameobject con los gameobjects de las cajas
    /// </summary>
    [SerializeField]
    private GameObject _boxes;

    /// <summary>
    /// Gameobject con los gameobjects de las bolas
    /// </summary>
    [SerializeField]
    private GameObject _balls;

    /// <summary>
    /// Gameobject con los gameobjects de los botones
    /// </summary>
    [SerializeField]
    private GameObject _buttons;

    /// <summary>
    /// Gameobject con los gameobjects de las areas de las camaras
    /// </summary>
    [SerializeField]
    private GameObject _cameraAreas;

    /// <summary>
    /// Gameobject con los gameobjects de las puertas
    /// </summary>
    [SerializeField]
    private GameObject _doors;
    #endregion

    #region properties
    /// <summary>
    /// La sala en la que se encuentra el jugador actualmente
    /// </summary>
    private int _currentRoom = 0;
    /// <summary>
    /// Referencia al player manager
    /// </summary>
    private PlayerManager _playerManager;

    /// <summary>
    /// La instancia del game manager
    /// </summary>
    static private GameManager _instance;

    /// <summary>
    /// Indica si esta pausado el juego
    /// </summary>
    public bool isPaused = false;

    /// <summary>
    /// Indica si esta ense�ando la puerta abriendose
    /// </summary>
    public bool IsShowingOpenDoor = false;

    static public GameManager Instance { get { return _instance; } }

    #endregion

    #region methods
    ///<summary>
    ///Inicializa todo lo necesario antes de jugar
    ///</summary>
    private void Init()
    {
        _playerManager.EnableInputs(false);

        ResetBoxes();
        ResetBalls();
        ResetButtons(); 
        ResetSaws();
        _playerManager.resetSize();
       
        _playerManager.goToSpawn(_currentRoom);

        Vector2 cameraPoint = _cameraAreas.GetComponentsInChildren<CameraAreaScript>()[_currentRoom].ClosestPoint(_playerManager.transform.position);
        Camera.main.GetComponent<CameraMovement>().setPosition(cameraPoint);

        CheckBoxes(0);

        StartCoroutine(_uiManager.FadeOut());

        _playerManager.EnableInputs(true);
    }

    ///<summary>
    ///Comprueba en cada caja si debe liberarse o no
    ///</summary>
    ///<param name="size">El tama�o del jugador</param>
    public void CheckBoxes(int size) {
        BoxManager[] boxManagers = _boxes.GetComponentsInChildren<BoxManager>();
        if (boxManagers.Length != 0)
        {
            foreach (BoxManager box in boxManagers)
            {
                box.CheckBox(size);
            }
        }
    }

    ///<summary>
    ///Reinicia las cajas a su posici�n inicial
    ///</summary>
    public void ResetBoxes()
    {
        SpawnItem[] spawnManagers = _boxes.GetComponentsInChildren<SpawnItem>();
        if (spawnManagers.Length != 0)
        {
            foreach (SpawnItem box in spawnManagers)
            {
                box.ResetObj();
            }
        }
    }

    ///<summary>
    ///Reinicia las bolas a su posici�n inicial
    ///<summary>
    public void ResetBalls()
    {
        SpawnItem[] spawnManagers = _balls.GetComponentsInChildren<SpawnItem>();
        if (spawnManagers.Length != 0)
        {
            foreach (SpawnItem ball in spawnManagers)
            {
                ball.ResetObj();
            }
        }
    }

    ///<summary>
    ///Reinicia las botones a su posici�n inicial
    ///<summary>
    public void ResetButtons()
    {
        BotonComponent[] spawnManagers = _buttons.GetComponentsInChildren<BotonComponent>();
        if (spawnManagers.Length != 0)
        {
            foreach (BotonComponent button in spawnManagers)
            {
                button.ResetBoton();
            }
        }
    }

    ///<summary>
    ///Reinicia las puertas a como si fuese la primera vez que se abren
    ///<summary>
    public void ResetDoors()
    {
        DoorComponent[] components = _doors.GetComponentsInChildren<DoorComponent>();
        if (components.Length != 0)
        {
            foreach (DoorComponent door in components)
            {
                door.resetFirstTime();
            }
        }
    }

    ///<summary>
    ///Reinicia las botones a su posici�n inicial
    ///<summary>
    public void ResetSaws()
    {
        SawComponent[] spawnManagers = _buttons.GetComponentsInChildren<SawComponent>();
        if (spawnManagers.Length != 0)
        {
            foreach (SawComponent button in spawnManagers)
            {
                button.ResetObj();
            }
        }
    }

    ///<summary>
    ///Reinicia los objetos y el personaje de la sala con una peque�a animaci�n
    ///<summary>

    //Mirar si se puede quitar la corutina
    public IEnumerator ResetRoom()
    {
        PlayerManager.Instance.EnableInputs(false);

        StartCoroutine(_uiManager.FadeIn());
        yield return new WaitWhile(() =>_uiManager.IsInAnimation());

        ResetBoxes();
        ResetBalls();
        ResetButtons(); 
        ResetSaws();
        ResetDoors();
        _playerManager.resetSize();
        _playerManager.goToSpawn(_currentRoom);

        Vector2 cameraPoint = _cameraAreas.GetComponentsInChildren<CameraAreaScript>()[_currentRoom].ClosestPoint(_playerManager.transform.position);
        Camera.main.GetComponent<CameraMovement>().setPosition(cameraPoint);

        _playerManager.GetComponent<PlayerAnimator>().IsDeath(false);

        StartCoroutine(_uiManager.FadeOut());
        yield return new WaitWhile(() => _uiManager.IsInAnimation());

        _playerManager.EnableInputs(true);
        _playerManager.SetAlive(true);
    }

    ///<summary>
    ///Mueve la camara a la siguiente sala
    ///</summary>
    ///<param name="door">La puerta entre la sala actual y la siguiente</param>
    public void passToNextRoom(DoorComponent door)
    {
        _currentRoom++;
        _playerManager.EnableInputs(false);
        _playerManager.resetSize();
        _playerManager.moveToNextRoom(_currentRoom, _cameraAreas.GetComponentsInChildren<CameraAreaScript>()[_currentRoom].ClosestPoint(_playerManager.getSpawnPoint(_currentRoom)), door);
    }

    ///<summary>
    ///Guarda la partida
    ///</summary>
    public void saveGame()
    {
        SaveScript.SaveFile(_currentRoom, SceneManager.GetActiveScene().name);
    }


    ///<summary>
    ///Ajusta las bolas de la UI al indicado
    ///</summary>
    public void ResizeBallsBar(int size)
    {
        _uiManager.ResizeBallsBar(size);
    }
    #endregion

    private void Awake()
    {
        _instance = this;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    private void Start()
    {
        _playerManager = PlayerManager.Instance;
        _currentRoom = SaveScript.room;
        Init();
    }
}
