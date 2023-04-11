using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingBallComponent : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Contador para asegurarse que no se activa 2 veces o mas
    /// </summary>
    private int _count = 0;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerManager.Instance.getSize() < 5 && _count == 0)   //Impide que obtenga mas de 5 bolas
        {
            Destroy(gameObject);
            PlayerManager.Instance.incrementSize();
            _count++;
        }
    }
}
