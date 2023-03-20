using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenusManager : MonoBehaviour
{
    public void ChangeToGameScene() //Carga la escena de juego desde el menu una vez pulsado el boton
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }

    public void QuitGame() // Sale del juego una vez al pulsar boton de salir
    {
        Application.Quit();
    }
    public void ChangeToMenuScene() //Carga la escena de juego desde el menu una vez pulsado el boton
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseGame() // Pausa el juego y abre el menu de pausa
    {
        SceneManager.LoadSceneAsync("Pausa", LoadSceneMode.Additive);
        Time.timeScale= 0f;
    }
   public void UnpauseGame() // Reanuda el juego cerrando el menu de pausa
    {
        SceneManager.UnloadSceneAsync("Pausa");
        Time.timeScale = 1.0f;
    }

    public void LoadGame()
    {
        SaveScript.LoadFile();
        SceneManager.LoadScene(SaveScript.scene);
        Time.timeScale = 1.0f;
    }
}
