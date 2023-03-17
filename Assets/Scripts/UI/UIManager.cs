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
    private bool _inAnimation;

    [SerializeField]
    private TMP_Text CounterText;

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

    public void UpdateCounter(int size) //Incrementa el contador de bolas de la UI en 1
    {
        string m = size.ToString() + "/5";
        CounterText.text = m;
    }
}
