using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public enum Buttons { Left = 0, Right = 1, Jump = 2, Drop = 3, Reset = 4};

public class ConfigScript : MonoBehaviour
{
    #region references
    /// <summary>
    /// Referencia el desplegable de los FPS
    /// </summary>
    [SerializeField]
    private TMP_Dropdown FPS_dropdown;

    /// <summary>
    /// Referencia el desplegable de los modos de ventana
    /// </summary>
    [SerializeField]
    private TMP_Dropdown Mode_dropdown;

    /// <summary>
    /// Referencia el desplegable de la resolucion
    /// </summary>
    [SerializeField]
    private TMP_Dropdown Resolution_dropdown;

    /// <summary>
    /// Referencia al deslizable del volumen
    /// </summary>
    [SerializeField]
    private Slider Volume_Slider;

    /// <summary>
    /// El array de los textos de los botones
    /// </summary>
    [SerializeField]
    private TMP_Text[] buttons_texts;
    #endregion

    #region properties
    /// <summary>
    /// Manager del menu anterior
    /// </summary>
    public static MenusManager PreviusSceneManager;

    /// <summary>
    /// Indica si esta en el menu principal o en el de pausa
    /// </summary>
    // Revisar si hace falta
    public static bool IsMenu;

    /// <summary>
    /// Boton que se esta seleccionando ahora mismo
    /// </summary>
    private Buttons buttonSelected;

    /// <summary>
    /// TMP_Text del boton que se esta seleccionando ahora mismo
    /// </summary>
    private TMP_Text textButton;

    /// <summary>
    /// Texto del boton antes de pulsarse 
    /// </summary>
    private string prevText;

    /// <summary>
    /// Array con los textos de los botones
    /// </summary>
    private string[] buttonsTexts = { "LeftArrow", "RightArrow", "Space", "X", "R"};

    /// <summary>
    /// Indica si esta obteniendo una tecla
    /// </summary>
    private bool IsGettingKey = false;

    /// <summary>
    /// Lista de los codigos de los botones
    /// </summary>
    public static Dictionary<Buttons,KeyCode> ButtonsCodes =new Dictionary<Buttons, KeyCode>{
        { Buttons.Left, KeyCode.LeftArrow }, 
        { Buttons.Right, KeyCode.RightArrow },
        { Buttons.Jump, KeyCode.Space }, 
        { Buttons.Drop, KeyCode.X },
        { Buttons.Reset, KeyCode.R } 
    };

    /// <summary>
    /// Datos del guardado de configuracion
    /// </summary>
    private ConfigData _configData = new ConfigData(2, 2, 3);
    #endregion
    #region methods

    /// <summary>
    /// Cambia los FPS del desplegable y lo guarda
    /// </summary>
    public void ChangeFPS()
    {
        int FPS = 0;
        switch (FPS_dropdown.value)
        {
            case 0:
                FPS = 30;
                break;
            case 1:
                FPS = 60;
                break;
            case 2:
                FPS = 120;
                break;
            case 3:
                FPS = 144;
                break;
        }

        _configData.FPS_Value = FPS_dropdown.value;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS;
        SaveFile();
    }
    
    /// <summary>
     /// Cambia el modo de la ventana del desplegable y lo guarda
     /// </summary>
    public void ChangeWindowMode()
    {
        switch (Mode_dropdown.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreen = true;
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 2:
                Screen.fullScreen = true;
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }
        _configData.Mode_Value = Mode_dropdown.value;
        SaveFile();
    }

    /// <summary>
    /// Cambia la resolucion del desplegable y lo guarda
    /// </summary>
    public void ChangeResolution()
    {

        switch (Resolution_dropdown.value)
        {
            case 0:
                Screen.SetResolution(640, 480, Screen.fullScreenMode);
                break;
            case 1:
                Screen.SetResolution(960, 540, Screen.fullScreenMode);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreenMode);
                break;
            case 3:
                Screen.SetResolution(1920, 1080, Screen.fullScreenMode);
                break;
        }
        _configData.Resolution_Value = Resolution_dropdown.value;
        SaveFile();
    }

    /// <summary>
    /// Vuelve al menu de pausa
    /// </summary>
    public void ChangeToPause()
    {
        SceneManager.LoadSceneAsync("Pausa", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Options");
        MenusManager.menuState = MenuState.PauseMenu;
    }

    /// <summary>
    /// Vuelve al menu principal
    /// </summary>
    public void ChangeToMenu()
    {
        SceneManager.UnloadSceneAsync("Options");
        PreviusSceneManager.ToggleUI();
        MenusManager.menuState = MenuState.StartMenu;
    }

    /// <summary>
    /// Cambia el boton por la tecla deseada
    /// </summary>
    /// <param name="position">Posicion del boton pulsado</param>
    public void ChangeButton(int position)
    {
        buttonSelected = (Buttons)position;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        textButton = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>();
        EventSystem.current.SetSelectedGameObject(null);
        prevText = textButton.text;
        textButton.text = "";
        IsGettingKey = true;
    }

    /// <summary>
    /// Guarda el los datos en un fichero
    /// </summary>
    private void SaveFile()
    {
        string destination = Application.persistentDataPath + "/config.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, _configData);
        file.Close();
    }

    /// <summary>
    /// Carga los datos desde el fichero
    /// </summary>
    /// <returns>Devuelve true si carga correctamente los datos</returns>
    public bool LoadFile()
    {
        string destination = Application.persistentDataPath + "/config.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogWarning("No se ha encontrado el archivo, se ha creado uno nuevo.");
            return false;
        }

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            ConfigData data = (ConfigData)bf.Deserialize(file);
            file.Close();
            _configData.FPS_Value = data.FPS_Value;

            _configData.Mode_Value = data.Mode_Value;

            _configData.Resolution_Value = data.Resolution_Value;

            _configData.ButtonsCodes = data.ButtonsCodes;

            _configData.ButtonsTexts = data.ButtonsTexts;
        }
        catch
        {
            file.Close();
            Debug.LogError("Archivo de configuracion corrupto, se ha reparado");
            SaveFile();
        }

        return true;
    }

    /// <summary>
    /// Carga toda la configuracion y actualiza la UI
    /// </summary>
    public void LoadConfig()
    {
        LoadFile();
        FPS_dropdown.value = _configData.FPS_Value;
        Resolution_dropdown.value = _configData.Resolution_Value;
        Mode_dropdown.value = _configData.Mode_Value;
        ButtonsCodes = _configData.ButtonsCodes;
        buttonsTexts = _configData.ButtonsTexts;
        for (int i = 0; i < 5; i++)
        {
            buttons_texts[i].text = buttonsTexts[i];
        }
    }

    /// <summary>
    /// Carga los inputs de los datos
    /// </summary>
    public static void LoadInputs()
    {
        string destination = Application.persistentDataPath + "/config.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogWarning("No se ha encontrado el archivo, se ha creado uno nuevo.");
            return;
        }

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            ConfigData data = (ConfigData)bf.Deserialize(file);
            file.Close();

            if (data.ButtonsCodes != null)
                    ButtonsCodes = data.ButtonsCodes;
        }
        catch
        {
            file.Close();
            Debug.LogError("Error al cargar la configuracion de botones");
        }
    }

    /// <summary>
    /// Para de esperar a recibir una tecla
    /// </summary>
    private void StopGettingKey()
    {
        _configData.ButtonsTexts = buttonsTexts;
        _configData.ButtonsCodes = ButtonsCodes;
        SaveFile();

        IsGettingKey = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Input.ResetInputAxes();
    }
    #endregion

    private void Start()
    {
        LoadConfig();
    }

    

    private void Update()
    {
        if (MenusManager.menuState == MenuState.ConfigMenu)
        {
            if (!IsGettingKey)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (IsMenu)
                    {
                        ChangeToMenu();
                    }
                    else
                    {
                        ChangeToPause();
                    }
                }
            }
            else if (IsGettingKey)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    textButton.text = prevText;
                    StopGettingKey();
                }
                else if (Input.anyKeyDown)
                {
                    foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKey(vKey))
                        {
                            if (ButtonsCodes.ContainsValue(vKey))
                            {
                                Buttons repeatedButton = Buttons.Left;
                                foreach (Buttons b in ButtonsCodes.Keys)
                                {
                                    if (ButtonsCodes[b] == vKey)
                                    {
                                        repeatedButton = b;
                                    }
                                }
                                ButtonsCodes[repeatedButton] = KeyCode.None;
                                buttons_texts[(int)repeatedButton].text = "";
                            }
                            string e = vKey.ToString();
                            ButtonsCodes[buttonSelected] = vKey;
                            textButton.text = e;
                            buttonsTexts[(int)buttonSelected] = e;
                            StopGettingKey();
                        }
                    }
                }
            }
        }
    }
}

/// <summary>
/// Datos de la configuracion del juego a guardar y cargar
/// </summary>
[System.Serializable]
struct ConfigData
{
    public int FPS_Value;
    public int Mode_Value;
    public int Resolution_Value;
    public Dictionary<Buttons,KeyCode> ButtonsCodes;
    public string[] ButtonsTexts;

    public ConfigData(int FPS_Value, int Mode_Value, int Resolution_Value)
    {
        this.FPS_Value = FPS_Value;
        this.Mode_Value = Mode_Value;
        this.Resolution_Value = Resolution_Value;
        this.ButtonsCodes = new Dictionary<Buttons, KeyCode>{
            { Buttons.Left, KeyCode.LeftArrow },
            { Buttons.Right, KeyCode.RightArrow },
            { Buttons.Jump, KeyCode.Space },
            { Buttons.Drop, KeyCode.X },
            { Buttons.Reset, KeyCode.R }
        };
        this.ButtonsTexts =new string[] { "LeftArrow", "RightArrow", "Space", "X", "R" };
    }
}

