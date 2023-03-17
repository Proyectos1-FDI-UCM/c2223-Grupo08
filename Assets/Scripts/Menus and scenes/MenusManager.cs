using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenusManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeToGameScene() //Carga la escena de juego desde el menu una vez pulsado el boton
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() // Sale del juego una vez al pulsar boton de salir
    {
        Application.Quit();
    }
    public void ChangeToMenuScene() //Carga la escena de juego desde el menu una vez pulsado el boton
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseGame()
    {
        SceneManager.LoadSceneAsync("Pausa");
    }
}
