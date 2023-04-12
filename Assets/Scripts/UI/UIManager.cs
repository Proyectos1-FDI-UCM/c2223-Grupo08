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
    private Animator _fadeAnimator; 
    
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
    public void FadeIn()
    {
        _fadeAnimator.SetBool("FadeOut", false);
    }

    /// <summary>
    /// Animacion para poner el fundido a negro
    /// </summary>
    public void FadeOut()
    {
        _fadeAnimator.SetBool("FadeOut", true);
    }

    /// <summary>
    /// Quita el fundido en negro al principio del nivel
    /// </summary>
    public void PlayStartTransition()
    {
        _fadeAnimator.SetTrigger("StartTransition");
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
