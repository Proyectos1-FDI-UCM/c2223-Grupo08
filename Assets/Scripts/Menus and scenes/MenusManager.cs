using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuState { StartMenu, PauseMenu, ConfigMenu, None};

public class MenusManager : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    private static bool firstTimeRuning = true;


    public static MenuState menuState;

    private void Start()
    {
        if (firstTimeRuning)
        {
            ConfigScript.LoadInputs();
            firstTimeRuning = false; 
            menuState = MenuState.StartMenu;
        }
    }

    void Update()
    {
        if (GameManager.Instance != null) {
            if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.isPaused && menuState == MenuState.PauseMenu)
            {
                UnpauseGame();
            } 
        }
    }
    public void NewGame() //Carga la escena de juego desde el menu una vez pulsado el boton
    {
        SaveScript.room = 0;
        SaveScript.scene = "Level 1";
        ChangeToGameScene();
    }

    public void ChangeToGameScene() //Carga la escena de juego desde el menu una vez pulsado el boton
    {
        SceneManager.LoadScene("Level 1");
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

    public static void PauseGame() // Pausa el juego y abre el menu de pausa
    {
        Input.ResetInputAxes();
        SceneManager.LoadSceneAsync("Pausa", LoadSceneMode.Additive);
        Time.timeScale= 0f;
        menuState = MenuState.PauseMenu;
        GameManager.Instance.isPaused = true;
    }
   public void UnpauseGame() // Reanuda el juego cerrando el menu de pausa
    {
        Input.ResetInputAxes();
        SceneManager.UnloadSceneAsync("Pausa");
        Time.timeScale = 1.0f;
        menuState = MenuState.None;
        GameManager.Instance.isPaused = false;
    }

    public void LoadGame()
    {
        SaveScript.LoadFile();
        SceneManager.LoadScene(SaveScript.scene);
        Time.timeScale = 1.0f;
    }
    public void SaveGame()
    {
        GameManager.Instance.saveGame();
    }

    public void ChangePauseToOptions()
    {
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Pausa");
        ConfigScript.IsMenu = false;
        menuState = MenuState.ConfigMenu;
    }
    public void ChangeMenuToOptions()
    {
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
        UI.active = false;
        ConfigScript.IsMenu = true;
        ConfigScript.PreviusSceneManager = this;
        menuState = MenuState.ConfigMenu;
    }

    public void ToggleUI()
    {
        UI.active = !UI.active;
        ConfigScript.PreviusSceneManager = this;
    }
}
