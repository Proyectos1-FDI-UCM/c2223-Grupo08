using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _boxes;

    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
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
}
