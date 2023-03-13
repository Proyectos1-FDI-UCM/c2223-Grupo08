using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private int targetFrameRate = 120;
    [SerializeField]
    private GameObject _boxes;
    [SerializeField]
    private GameObject _balls;
    [SerializeField]
    private GameObject _buttons;
    [SerializeField]
    private GameObject _cameraAreas;

    private int _currentRoom = 0;
    private PlayerManager _playerManager;

    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _playerManager = PlayerManager.Instance;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        Init();
    }

    //Inicializa todo lo necesario antes de jugar
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
        Camera.main.GetComponent<CameraMovement>().MoveCamera(cameraPoint);

        CheckBoxes(0);

        StartCoroutine(_uiManager.FadeOut());

        _playerManager.EnableInputs(true);
    }

    //Comprueba en cada caja si debe liberarse o no
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

    //Reinicia las cajas a su posición inicial
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

    //Reinicia las bolas a su posición inicial
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

    //Reinicia las botones a su posición inicial
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
    
    //Reinicia las botones a su posición inicial
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

    //Reinicia los objetos y el personaje de la sala con una pequeña animación
    public IEnumerator ResetRoom()
    {
        PlayerManager.Instance.EnableInputs(false);

        StartCoroutine(_uiManager.FadeIn());
        yield return new WaitWhile(() =>_uiManager.IsInAnimation());

        ResetBoxes();
        ResetBalls();
        ResetButtons(); 
        ResetSaws();
        _playerManager.resetSize();
        _playerManager.goToSpawn(_currentRoom);

        Vector2 cameraPoint = _cameraAreas.GetComponentsInChildren<CameraAreaScript>()[_currentRoom].ClosestPoint(_playerManager.transform.position);
        Camera.main.GetComponent<CameraMovement>().MoveCamera(cameraPoint);

        _playerManager.SendMessage("IsDeath", false);

        StartCoroutine(_uiManager.FadeOut());
        yield return new WaitWhile(() => _uiManager.IsInAnimation());

        _playerManager.EnableInputs(true);
        _playerManager.SetAlive(true);
    }

    public void UpdateCounter(int size) //Incrementa el contador de bolas de la UI en 1
    {
        _uiManager.UpdateCounter(size);
    }

    public void nextRoom(DoorComponent door)
    {
        _currentRoom++;
        _playerManager.EnableInputs(false);
        _playerManager.moveToNextRoom(_currentRoom, _cameraAreas.GetComponentsInChildren<CameraAreaScript>()[_currentRoom].ClosestPoint(_playerManager.getSpawnPoint(_currentRoom)), door);
    }

}
