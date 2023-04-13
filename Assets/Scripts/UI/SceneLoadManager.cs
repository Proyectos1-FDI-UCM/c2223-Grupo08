using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Si es true la siguiente escena en cargar es el main menu
    /// </summary>
    [Tooltip("True para que la siguiente escena sea el main menu")]
    public bool NextSceneMenu = false;

    /// <summary>
    /// PlayerAnimator del player
    /// </summary>
    [SerializeField]
    private PlayerAnimator _playerAnimator;

    /// <summary>
    /// Referencia del animador
    /// </summary>
    [SerializeField]
    private Animator fadeAnimator;
    #endregion

    #region methods
    /// <summary>
    /// Reproduce la animacion de fin de nivel
    /// </summary>
    public void LoadNextScene()
    {
        fadeAnimator.SetTrigger("NextLevelTransition");
    }

    /// <summary>
    /// Carga la siguiente escena
    /// </summary>
    /// <returns></returns>
    public void NextSceneLoad()
    {
        int nextSceneIndex;
        if (NextSceneMenu)
        {
            nextSceneIndex = 0;
        }
        else
        {
            nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }
        SaveScript.room = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager.Instance.EnableInputs(false);
        _playerAnimator.PlayLoadSceneAnimation();
        LoadNextScene();
    }
    
}
