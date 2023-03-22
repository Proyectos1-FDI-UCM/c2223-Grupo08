using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ConfigScript : MonoBehaviour
{
    public static int Volume = 100;
    public static FullScreenMode WindowMode = FullScreenMode.ExclusiveFullScreen;
    public static int FPS = 120;

    public static MenusManager PreviusSceneManager;
    public static bool IsMenu;
    private ConfigData _configData = new ConfigData(2,2,3);

    [SerializeField]
    private TMP_Dropdown FPS_dropdown;
    [SerializeField]
    private TMP_Dropdown Mode_dropdown;
    [SerializeField]
    private TMP_Dropdown Resolution_dropdown;
    [SerializeField]
    private Slider Volume_Slider;

    private void Start()
    {
        Screen.fullScreen = true;
        LoadConfig();
        /*QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS;
        FPS_dropdown.value = FPS_Value;

        Screen.fullScreen = true;
        Screen.fullScreenMode = WindowMode;

        Resolution_dropdown.value = Resolution_Value;
        ChangeResolution();*/
    }

    public void ChangeFPS()
    {
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
    }
    public void ChangeWindowMode()
    {
        switch (Mode_dropdown.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                WindowMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                WindowMode = FullScreenMode.FullScreenWindow;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                WindowMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }
        _configData.Mode_Value = Mode_dropdown.value;
    }
    public void ChangeResolution()
    {
        switch (Resolution_dropdown.value)
        {
            case 0:
                Screen.SetResolution(640 , 480, WindowMode);
                break;
            case 1:
                Screen.SetResolution(960 , 540, WindowMode);
                break;
            case 2:
                Screen.SetResolution(1280 , 720, WindowMode);
                break;
            case 3:
                Screen.SetResolution(1920 , 1080, WindowMode);
                break;
        }
        _configData.Resolution_Value = Resolution_dropdown.value;
    }

    private void Update()
    {
        if (MenusManager.IsInConfig)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsMenu) {
                    ChangeToMenu(); 
                }
                else
                {
                    ChangeToPause();
                }
            }
        }
    }

    public void ChangeToPause()
    {
        SaveFile();
        SceneManager.LoadSceneAsync("Pausa", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Options");
    }

    public void ChangeToMenu()
    {
        SaveFile();
        SceneManager.UnloadSceneAsync("Options");
        PreviusSceneManager.ToggleUI();
    }

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

    public bool LoadFile()
    {
        string destination = Application.persistentDataPath + "/config.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return false;
        }

        BinaryFormatter bf = new BinaryFormatter();
        ConfigData data = (ConfigData)bf.Deserialize(file);
        file.Close();

        _configData.FPS_Value = data.FPS_Value;
        _configData.Mode_Value = data.Mode_Value;
        _configData.Resolution_Value = data.Resolution_Value;
        return true;
    }

    public void LoadConfig()
    {
        LoadFile();
        FPS_dropdown.value = _configData.FPS_Value;
        Resolution_dropdown.value = _configData.Resolution_Value;
        Mode_dropdown.value = _configData.Mode_Value;
    }
}

[System.Serializable]
struct ConfigData
{
    public int FPS_Value;
    public int Mode_Value;
    public int Resolution_Value;

    public ConfigData(int FPS_Value, int Mode_Value, int Resolution_Value)
    {
        this.FPS_Value = FPS_Value;
        this.Mode_Value = Mode_Value;
        this.Resolution_Value = Resolution_Value;
    }
}

