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

    private int _currentRoom = 0;

    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        Init();
    }

    //Inicializa todo lo necesario antes de jugar
    private void Init()
    {
        PlayerManager.Instance.EnableInputs(false);

        ResetBoxes();
        ResetBalls();
        ResetButtons();
        PlayerManager.Instance.resetSize();
        PlayerManager.Instance.goToSpawn(_currentRoom);
        CheckBoxes(0);

        StartCoroutine(_uiManager.FadeOut());

        PlayerManager.Instance.EnableInputs(true);
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

    //Reinicia los objetos y el personaje de la sala con una pequeña animación
    public IEnumerator ResetRoom()
    {
        PlayerManager.Instance.EnableInputs(false);

        StartCoroutine(_uiManager.FadeIn());
        yield return new WaitWhile(() =>_uiManager.IsInAnimation());

        ResetBoxes();
        ResetBalls();
        ResetButtons();
        PlayerManager.Instance.resetSize();
        PlayerManager.Instance.goToSpawn(_currentRoom);

        StartCoroutine(_uiManager.FadeOut());
        yield return new WaitWhile(() => _uiManager.IsInAnimation());

        PlayerManager.Instance.EnableInputs(true);
    }
}
