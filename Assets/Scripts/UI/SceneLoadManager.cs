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
    #endregion

    #region properties
    /// <summary>
    /// Referencia del animador
    /// </summary>
    private Animator transitionAnimator;
    #endregion

    #region methods
    /// <summary>
    /// Carga la siguiente escena
    /// </summary>
    void LoadNextScene()
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
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    /// <summary>
    /// Carga la escena
    /// </summary>
    /// <param name="sceneIndex">La escena a cargar</param>
    /// <returns></returns>
    //Ver si se puede quitar la corutina
    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
    #endregion

    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager.Instance.EnableInputs(false);
        _playerAnimator.LoadScene();
        LoadNextScene();
    }
    
}
