using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementSizeBarra : MonoBehaviour
{
    #region references
    /// <summary>
    /// Arrary con los huecos de las bolas
    /// </summary>
    [SerializeField]
    private GameObject[] _rellenoBolas;
    #endregion

    #region methods
    /// <summary>
    /// Actualiza la barra a las bolas dadas
    /// </summary>
    /// <param name="size">Numero de bolas</param>
    public void ResizeBar(int size)
    {
        for (int i = 0; i < 5; i++)
        {
            if(i < size)
            {
                _rellenoBolas[i].SetActive(true);
            }
            else
            {
                _rellenoBolas[i].SetActive(false);
            }
        }
    }
    #endregion
}
