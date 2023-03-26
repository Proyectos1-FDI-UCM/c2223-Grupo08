using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementSizeBarra : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _rellenoBolas;

    public void ResizeBar(int size)
    {
        for (int i = 0; i < 5; i++)
        {
            if(i < size)
            {
                _rellenoBolas[i].active = true;
            }
            else
            {
                _rellenoBolas[i].active = false;
            }
        }
    }
}
