using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static private PlayerManager _instance;   //Instancia del manager
    static public PlayerManager Instance { get { return _instance; } }

    private Transform _transform;
    private MovementController _movementController;
    private int _PlayerSize = 0;    //Indica el tamaño del jugador

    public int getSize() { return _PlayerSize; } //Devuelve el tamaño del jugador

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _movementController = GetComponent<MovementController>();
    }

    //Aumenta en 1 el tamaño
    public void incrementSize()
    {
        _PlayerSize++;
        _transform.localScale += new  Vector3(0.2f,0.2f,0);
        GameManager.Instance.CheckBoxes(_PlayerSize);
        _movementController.SetSlowFactor(_PlayerSize);
        _movementController.SetJumpFactor(_PlayerSize);
    }

    //Devuelve el tamaño a 0
    public void resetSize()
    {
        _PlayerSize = 0;
        _transform.localScale = Vector3.one;
        GameManager.Instance.CheckBoxes(_PlayerSize);
        _movementController.SetSlowFactor(_PlayerSize);
        _movementController.SetJumpFactor(_PlayerSize);
    }
}
