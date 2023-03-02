using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallsCounter : MonoBehaviour
{
    private TextMeshPro CounterText;
    private int balls = 0;

    void Start()
    {
        CounterText.GetComponent<TextMeshPro>();
    }
    public void IncreaseCounter() //Incrementa el contador de bolas de la UI en 1
    {
        balls++;
        CounterText.text = balls.ToString() + "/5";
    }
    public void ResetCounter() // Resetea el contador de bolas de la UI a 0
    {
        balls = 0;
        CounterText.text = balls.ToString() + "/5";
    }
}
