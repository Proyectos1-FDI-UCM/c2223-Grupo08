using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _fade; 
    
    [SerializeField]
    private IncrementSizeBarra _balls;
    private bool _inAnimation;

    public bool IsInAnimation() { return _inAnimation; }

    //Animacion para quitar el fundido a negro
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

    //Animacion para poner el fundido a negro
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

    public void ResizeBallsBar(int size)
    {
        _balls.ResizeBar(size);
    }
}
