using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signsposts : MonoBehaviour
{
    [SerializeField] private GameObject Info; // Mensaje de presione el boton para mostrar mensaje
    [SerializeField] private GameObject ShowInfo; // Mensaje del cartel

    [SerializeField] private LayerMask Character;

    public bool InfoEnabled;
    public bool ShowInfoEnabled;

    // Start is called before the first frame update
    void Start()
    {
        Info.SetActive(false); // Desactivamos los dos mensajes para que no se vean nada mas empezar
        ShowInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InfoEnabled = Physics2D.OverlapCircle(this.transform.position, 1f, Character); 

        if (InfoEnabled == true) // Si dentro del �rea designada detecta que est� el jugador muestra el mensaje de presionar bot�n si no desaparece
        {
            Info.SetActive(true);
        }
        if (InfoEnabled == false)
        {
            Info.SetActive(false);
        }

        ShowInfoEnabled = Physics2D.OverlapCircle(this.transform.position, 1f, Character);

        if (ShowInfoEnabled == true && Input.GetKeyDown(KeyCode.Return)) // Si el jugador presiona la tecla saldr� el mensaje que muestra el cartel y si el jugador se va lejos desaparece
        {
            ShowInfo.SetActive(true);
        }
        if (ShowInfoEnabled == false)
        {
            ShowInfo.SetActive(false);
        }
    }
}
