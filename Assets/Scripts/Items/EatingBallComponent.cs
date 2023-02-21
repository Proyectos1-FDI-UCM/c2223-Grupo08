using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingBallComponent : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerManager.Instance.getSize() < 5)   //Impide que obtenga mas de 5 bolas
        {
            Destroy(gameObject);
            PlayerManager.Instance.incrementSize();
        }
    }
}
