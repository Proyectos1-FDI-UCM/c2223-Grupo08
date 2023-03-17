using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusInput : MonoBehaviour
{
    private MenusManager menusManager;
    // Start is called before the first frame update
    void Start()
    {
        menusManager = GetComponent<MenusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menusManager.PauseGame();
        }
    }
}
