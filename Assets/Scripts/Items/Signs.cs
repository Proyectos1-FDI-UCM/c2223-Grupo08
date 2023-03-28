using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Signs : MonoBehaviour
{
    [SerializeField] private Text SignText;

    // Start is called before the first frame update
    void Start()
    {
        SignText.text = "Hola";
    }
}
