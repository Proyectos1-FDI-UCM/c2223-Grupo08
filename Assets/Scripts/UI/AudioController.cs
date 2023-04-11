using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    #region references
    [SerializeField] private AudioClip _audioDoorOpen;
    [SerializeField] private AudioClip _audioDoorClosed;
    [SerializeField] private AudioClip _audioButton;
    [SerializeField] private AudioClip _audioPlatform;
    [SerializeField] private AudioClip _audioRock;
    [SerializeField] private AudioClip _audioMechanicalSaw;

    [SerializeField] private AudioClip _audioMusicMenu;
    [SerializeField] private AudioClip _audioMenuButton;

    [SerializeField] private AudioClip _audioWalk;
    [SerializeField] private AudioClip _audioJump;
    [SerializeField] private AudioClip _audioDeath;
    #endregion

    #region 
    /// <summary>
    /// Refetencia al AudioSource
    /// </summary>
    private AudioSource _audio;
    #endregion
    #region methods
    public void PlaySound(int Pos)
    {

    }
    #endregion
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }
}
