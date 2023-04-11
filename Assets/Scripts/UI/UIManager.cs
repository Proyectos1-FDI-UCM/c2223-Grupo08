using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// GameObjects con el fade
    /// </summary>
    [SerializeField]
    private GameObject _fade; 
    
    /// <summary>
    /// GameObject de la barra de bolas
    /// </summary>
    [SerializeField]
    private IncrementSizeBarra _balls;
    #endregion

    #region properties
    /// <summary>
    /// Indica si esta en animacion
    /// </summary>
    private bool _inAnimation;

    public bool IsInAnimation() { return _inAnimation; }
    #endregion

    #region methods
    /// <summary>
    /// Animacion para quitar el fundido a negro
    /// </summary>
    /// <returns></returns>
    // Mirar si se puede quitar la corutina
    public IEnumerator FadeOut()
    {
        _inAnimation = true;
        _fade.SetActive(true);

        Color c = _fade.GetComponent<Image>().color;
        for (float alpha = 1; alpha >= 0; alpha -= 0.05f)
        {
            c.a = alpha;
            c.a += alpha;
            _fade.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.05f);
        }

        _fade.SetActive(false);
        _inAnimation = false;
    }

    /// <summary>
    /// Animacion para poner el fundido a negro
    /// </summary>
    /// <returns></returns>
    // Mirar si se puede quitar la corutina
    public IEnumerator FadeIn()
    {
        _inAnimation = true;
        _fade.SetActive(true);

        Color c = _fade.GetComponent<Image>().color;
        for (float alpha = 0; alpha <= 1; alpha += 0.05f)
        {
            c.a = alpha;
            c.a += alpha;
            _fade.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.05f);
        }

        _inAnimation = false;
    }

    /// <summary>
    /// Actualiza la barra de bolas
    /// </summary>
    /// <param name="size">Numero de bolas</param>
    public void ResizeBallsBar(int size)
    {
        _balls.ResizeBar(size);
    }
    #endregion
}
