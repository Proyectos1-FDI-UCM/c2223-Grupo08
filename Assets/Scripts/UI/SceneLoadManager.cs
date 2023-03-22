using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private Animator transitionAnimator;
    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (true)
        {
            LoadNextScene();
        }
    }
    void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
}
