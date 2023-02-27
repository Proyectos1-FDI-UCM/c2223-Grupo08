using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int targetFrameRate = 120;
    [SerializeField]
    private GameObject _boxes;
    [SerializeField]
    private GameObject _balls;

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
        ResetRoom();
        CheckBoxes(0);
    }

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

    public void ResetRoom()
    {
        ResetBoxes();
        ResetBalls();
        PlayerManager.Instance.resetSize();
        PlayerManager.Instance.goToSpawn(_currentRoom);
    }
}
