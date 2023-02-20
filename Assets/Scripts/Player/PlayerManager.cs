using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public PlayerManager instance;   //Instancia del manager

    private Transform _transform;
    private int _PlayerSize = 0;    //Indica el tama�o del jugador

    public int getSize() { return _PlayerSize; } //Devuelve el tama�o del jugador

    // Start is called before the first frame update
    void Start()
    {
        instance= this;
        _transform = GetComponent<Transform>();
    }

    //Aumenta en 1 el tama�o
    public void incrementSize()
    {
        _PlayerSize++;
        _transform.localScale += new  Vector3(0.2f,0.2f,0);
    }

    //Devuelve el tama�o a 0
    public void resetSize()
    {
        _PlayerSize = 0;
        _transform.localScale = Vector3.one;
    }
}
