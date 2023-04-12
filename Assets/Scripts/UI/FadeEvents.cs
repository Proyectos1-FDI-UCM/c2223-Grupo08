using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEvents : MonoBehaviour
{
    #region references
    /// <summary>
    /// Referencia al SceneLoadManager
    /// </summary>
    [SerializeField]
    private SceneLoadManager _sceneLoadManager;
    #endregion

    #region methods
    /// <summary>
    /// Carga la siguiente escena
    /// </summary>
    public void NextSceneLoad()
    {
        _sceneLoadManager.NextSceneLoad();
    }

    /// <summary>
    /// Reinicia la sala
    /// </summary>
    public void ResetRoom()
    {
        GameManager.Instance.ResetRoom();
    }

    /// <summary>
    /// Devuelve el control al jugador
    /// </summary>
    public void EnableInputs()
    {
        PlayerManager.Instance.EnableInputs(true);
    }
    #endregion
}
