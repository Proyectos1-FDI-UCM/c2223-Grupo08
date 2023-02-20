using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public PlayerManager instance;

    private Transform _transform;
    int _PlayerSize = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance= this;
        _transform = GetComponent<Transform>();
    }

    void incrementSize()
    {
        _PlayerSize++;
        _transform.localScale
    }

    void resetSize()
    {
        _PlayerSize--;
    }
}
