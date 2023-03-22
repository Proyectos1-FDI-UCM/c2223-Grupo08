using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ConfigScript : MonoBehaviour
{
    public static int Volume = 100;
    public static FullScreenMode WindowMode = FullScreenMode.ExclusiveFullScreen;
    public static int FPS = 120;
    public static int Resolution_Value = 3;
    private static int FPS_Value = 2;

    public static MenusManager PreviusSceneManager;
    public static bool IsMenu;

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
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS;
        FPS_dropdown.value = FPS_Value;

        Screen.fullScreen = true;
        Screen.fullScreenMode = WindowMode;

        Resolution_dropdown.value = Resolution_Value;
        ChangeResolution();
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

        FPS_Value = FPS_dropdown.value;
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
        Resolution_Value = Resolution_dropdown.value;
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
        SceneManager.LoadSceneAsync("Pausa", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Options");
    }

    public void ChangeToMenu()
    {
        SceneManager.UnloadSceneAsync("Options");
        PreviusSceneManager.ToggleUI();
    }


}
