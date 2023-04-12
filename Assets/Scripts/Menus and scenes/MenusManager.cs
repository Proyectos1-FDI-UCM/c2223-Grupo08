using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuState { StartMenu, PauseMenu, ConfigMenu, None};

public class MenusManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// GameObject de la UI
    /// </summary>
    [SerializeField] private GameObject UI;

    /// <summary>
    /// Referencia al AudioController
    /// </summary>
    [SerializeField] private AudioController _audioController;
    #endregion
    #region properties
    /// <summary>
    /// Indica si es la primera vez que se inicia el script
    /// </summary>
    private static bool firstTimeRuning = true;

    /// <summary>
    /// Indica que estado se encuenta el menu
    /// </summary>
    public static MenuState menuState;
    #endregion

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

    #region methods
    /// <summary>
    /// Carga la escena de juego desde el menu una vez pulsado el boton
    /// </summary>
    public void NewGame()
    {
        SaveScript.room = 0;
        SaveScript.scene = "Level 1";
        ChangeToGameScene();
    }

    /// <summary>
    /// Carga la escena de juego desde el menu una vez pulsado el boton
    /// </summary>
    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Sale del juego una vez al pulsar boton de salir
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Carga la escena de juego desde el menu una vez pulsado el boton
    /// </summary>
    public void ChangeToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Pausa el juego y abre el menu de pausa
    /// </summary>
    public static void PauseGame()
    {
        Input.ResetInputAxes();
        SceneManager.LoadScene("Pausa", LoadSceneMode.Additive);
        Time.timeScale = 0f;
        menuState = MenuState.PauseMenu;
        GameManager.Instance.isPaused = true;
    }

    /// <summary>
    /// Reanuda el juego cerrando el menu de pausa
    /// </summary>
    public void UnpauseGame()
    {
        Input.ResetInputAxes();
        SceneManager.UnloadScene("Pausa");
        Time.timeScale = 1.0f;
        menuState = MenuState.None;
        GameManager.Instance.isPaused = false;
    }

    /// <summary>
    /// Carga la partida guardada
    /// </summary>
    public void LoadGame()
    {
        SaveScript.LoadFile();
        SceneManager.LoadScene(SaveScript.scene);
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Guarda el juego
    /// </summary>
    public void SaveGame()
    {
        GameManager.Instance.saveGame();
    }

    /// <summary>
    /// Cambia del menu de pausa al de opciones
    /// </summary>
    public void ChangePauseToOptions()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
        SceneManager.UnloadScene("Pausa");
        ConfigScript.IsMenu = false;
        menuState = MenuState.ConfigMenu;
    }

    /// <summary>
    /// Cambia del menu principal al de opciones
    /// </summary>
    public void ChangeMenuToOptions()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
        UI.active = false;
        ConfigScript.IsMenu = true;
        ConfigScript.PreviusSceneManager = this;
        menuState = MenuState.ConfigMenu;
    }

    /// <summary>
    /// Activa o desactiva la UI
    /// </summary>
    public void ToggleUI()
    {
        UI.active = !UI.active;
        ConfigScript.PreviusSceneManager = this;
    }

    public void PlayButtonAudio(){
        _audioController.PlaySound(Audios.MenuButton);
    }
    #endregion
}
