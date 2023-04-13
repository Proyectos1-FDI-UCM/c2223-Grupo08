using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Referencias a los audios source de los hijos
    /// </summary>
    private AudioSource[] _audiosSources;
    #endregion

    #region methods
    /// <summary>
    /// Pausa todos los audios
    /// </summary>
    public void PauseSounds()
    {
        foreach(AudioSource audioSource in _audiosSources)
        {
            audioSource.Pause();
        }
    }

    /// <summary>
    /// Continua todos los audios
    /// </summary>
    public void ResumeSounds()
    {
        foreach (AudioSource audioSource in _audiosSources)
        {
            audioSource.Play();
        }
    }
    #endregion

    private void Start()
    {
        _audiosSources = GetComponentsInChildren<AudioSource>();
    }
}
