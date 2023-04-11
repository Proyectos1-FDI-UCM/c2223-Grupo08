using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signsposts : MonoBehaviour
{
    #region references
    /// <summary>
    ///  Mensaje del cartel
    /// </summary>
    [SerializeField] private GameObject Info;
    
    /// <summary>
    /// La LayerMask del personaje
    /// </summary>
    [SerializeField] private LayerMask Character;
    #endregion

    #region properties
    /// <summary>
    /// Indica si la informacion esta activada
    /// </summary>
    public bool InfoEnabled;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        Info.SetActive(false); // Desactivamos el mensaje mensajes para que no se vean nada mas empezar
    }

    // Update is called once per frame
    void Update()
    {
        InfoEnabled = Physics2D.OverlapCircle(this.transform.position, 1f, Character); 

        if (InfoEnabled == true) // Si dentro del área designada detecta que está el jugador muestra el mensaje 
        {
            Info.SetActive(true);
        }
        if (InfoEnabled == false)
        {
            Info.SetActive(false);
        }        
    }
}
