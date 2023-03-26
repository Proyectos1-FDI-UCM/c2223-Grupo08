using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [Tooltip("True para que la siguiente escena sea el main menu")]
    public bool NextSceneMenu = false;

    [SerializeField]
    private PlayerAnimator _playerAnimator;
    private Animator transitionAnimator;
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

    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
}
